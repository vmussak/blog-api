using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.CreateBlogPost
{
    public class CreateBlogPostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
