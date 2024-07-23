using Blog.Core.UseCases.GetAllPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.MongoDb.Collections
{
    public class PostsCollection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CommentsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
