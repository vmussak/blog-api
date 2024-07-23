using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Model
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlogPostModel BlogPost { get; set; }
    }
}
