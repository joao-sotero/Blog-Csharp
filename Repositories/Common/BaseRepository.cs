using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        protected readonly SqlConnection _connection;

        public BaseRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TEntity> GetAll()
            => _connection.GetAll<TEntity>();

        public TEntity Get(long id)
            => _connection.Get<TEntity>(id);

        public long Create(TEntity request)
            => _connection.Insert<TEntity>(request);

        public bool Update(TEntity request)
            => _connection.Update<TEntity>(request);

        public bool Delete(long id)
        {
            if (id > 0)
            {
                var entity = Get(id);
                if(entity != null)
                    return _connection.Delete<TEntity>(entity);
            }
            return default;
        }
    }
}
//private Dictionary<string, string> _ColumnNames => _GetColumnNames();

//private Dictionary<string, string> _GetColumnNames()
//{
//    var columnNames = new Dictionary<string, string>();
//    var propertyInfos = typeof(T).GetProperties();

//    foreach (var property in propertyInfos)
//    {
//        var attribute = property.GetCustomAttributes(false)[0];
//        if (attribute is DescriptionAttribute description)
//            columnNames.Add(property.Name, description.Description);
//    }

//    return columnNames;
//}