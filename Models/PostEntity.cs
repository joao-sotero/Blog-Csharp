using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("Post")]
    public class PostEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}