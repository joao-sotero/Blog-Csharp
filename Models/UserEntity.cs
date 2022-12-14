using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class UserEntity
    {
        public UserEntity()
         => Roles = new List<RoleEntity>();

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        [Write(false)]
        public List<RoleEntity> Roles { get; set; }
    }
}