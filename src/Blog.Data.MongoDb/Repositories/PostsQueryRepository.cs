using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.UseCases.GetAllPosts;
using Blog.Data.MongoDb.Collections;
using Blog.Data.MongoDb.Mappers;
using MongoDB.Driver;
using System.Threading;

namespace Blog.Data.MongoDb.Repositories
{
    public class PostsQueryRepository : IBlogPostQueryRepository
    {
        private readonly IMongoCollection<PostsCollection> _collection;

        public PostsQueryRepository(IMongoCollection<PostsCollection> collection)
        {
            _collection = collection;
        }

        public async Task AddComment(Comment comment, CancellationToken cancellationToken)
        {
            var filter = Builders<PostsCollection>.Filter.Where(x => x.Id == comment.BlogPostId);
            var blogPosts = await _collection.FindAsync(filter, cancellationToken: cancellationToken);

            var thePost = blogPosts.FirstOrDefault();

            if (thePost == null) return;

            thePost.CommentsCount++;

            await _collection.ReplaceOneAsync(filter, thePost);
        }

        public async Task Create(BlogPost blogPost, CancellationToken cancellationToken)
        {
            var collection = new PostsCollection
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                CreatedAt = blogPost.CreatedAt,
                CommentsCount = 0
            };

            await _collection.InsertOneAsync(collection);
        }

        public async Task<IEnumerable<GetAllPostsPresenter>> GetAllPosts(CancellationToken cancellationToken)
        {
            var postsFind = await _collection.FindAsync(Builders<PostsCollection>.Filter.Empty, cancellationToken: cancellationToken);
            var allPosts = postsFind.ToList();

            if(allPosts == null || !allPosts.Any())
            {
                return Enumerable.Empty<GetAllPostsPresenter>();
            }

            return allPosts.Select(x => x.ToPresenter());
        }
    }
}
