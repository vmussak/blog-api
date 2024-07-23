using Blog.Core.UseCases.GetAllPosts;
using Blog.Data.MongoDb.Collections;

namespace Blog.Data.MongoDb.Mappers
{
    public static class PostsMapper
    {
        public static GetAllPostsPresenter ToPresenter(this PostsCollection collection)
        {
            return new GetAllPostsPresenter
            {
                Id = collection.Id,
                Title = collection.Title,
                CommentsCount = collection.CommentsCount,
                CreatedAt = collection.CreatedAt,
            };
        }
    }
}
