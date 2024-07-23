using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class BlogPost
    {
        public BlogPost(string title, string content)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
