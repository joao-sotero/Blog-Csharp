using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories.Category
{
    public class CategoryRepository : BaseRepository<CategoryEntity>
    {
        public CategoryRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}