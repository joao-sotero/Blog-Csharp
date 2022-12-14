using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(SqlConnection connection) : base(connection) { }


        public List<UserEntity> GetWithRoles()
        {
            var query = @"
               SELECT 
                    [User].*,
                    [Role].*
                FROM   
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<UserEntity>();

            var items = _connection.Query<UserEntity, RoleEntity, UserEntity>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;
                }, splitOn: "Id");

            return users;
        }

    }
}