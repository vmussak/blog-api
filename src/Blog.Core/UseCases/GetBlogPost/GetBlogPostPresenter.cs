using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.GetBlogPost
{
    public class GetBlogPostPresenter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<GetBlogPostCommentPresenter>? Comments { get; set; }
    }

    public class GetBlogPostCommentPresenter
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
