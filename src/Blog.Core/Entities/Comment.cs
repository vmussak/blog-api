using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Comment
    {
        public Comment(Guid blogPostId, string content)
        {
            Id = Guid.NewGuid();
            BlogPostId = blogPostId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public Guid BlogPostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
