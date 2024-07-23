using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.GetAllPosts
{
    public class GetAllPostsPresenter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentsCount { get; set; }
    }
}
