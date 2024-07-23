using System.Text.Json.Serialization;

namespace Blog.Core.UseCases.CreateComment
{
    public class CreateCommentRequest
    {
        [JsonIgnore]
        public Guid PostId { get; set; }

        public string Content { get; set; }
    }
}
