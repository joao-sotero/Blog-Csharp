using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories.Role
{
    public class RoleRepository : BaseRepository<RoleEntity>
    {
        public RoleRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}