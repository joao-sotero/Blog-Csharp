using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories.Tag
{
    public class TagRepository : BaseRepository<TagEntity>
    {
        public TagRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}