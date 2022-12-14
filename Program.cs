using Blog.Models;
using Blog.Repositories.Role;
using Blog.Repositories.User;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = "Server=127.0.0.1,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
        private static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            //var repoRole = new RoleRepository(connection);
            //ReadRoles(repoRole);
            //ReadRole(repoRole);
            //CreateRole(repoRole);
            //UpdateRole(repoRole, 2);
            //DeleteRole(repoRole, 2);

            var repoUser = new UserRepository(connection);
            //CreateUser(repoUser);
            ReadUsers(repoUser);
            //ReadUser(repoUser);
            //UpdateUser(repoUser, 7);
            //DeleteUser(repoUser, 1002);

            connection.Close();
        }

        public static void ReadRoles<TModel>(RoleRepository repo)
        {
            var itens = repo.GetAll();

            foreach (var item in itens)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadRole(RoleRepository repo)
        {
            var role = repo.Get(1);

            Console.WriteLine($"{role.Id} - {role.Name}");
        }

        public static void CreateRole(RoleRepository repo)
        {
            var user = new RoleEntity
            {
                Name = "Role",
                Slug = "Role"
            };

            var id = repo.Create(user);

            Console.WriteLine($"Usuario criado com o id: {id}");
        }

        public static void UpdateRole(RoleRepository repo, int id)
        {
            var Role = new RoleEntity
            {
                Id = id,
                Name = "Role",
                Slug = "Role"
            };

            var alt = repo.Update(Role);

            Console.WriteLine($"registro alterado: {alt}");

        }

        public static void DeleteRole(RoleRepository repo, int id)
        {
            var del = repo.Delete(id);

            Console.WriteLine($"registro excluido: {del}");
        }


        public static void ReadUsers(UserRepository repo)
        {
            var users = repo.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);

                foreach(var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }

        public static void ReadUser(UserRepository repo)
        {
            var user = repo.Get(1);

            Console.WriteLine($"{user.Id} - {user.Name}");
        }

        public static void CreateUser(UserRepository repo)
        {
            var user = new UserEntity
            {
                Bio = "Equipe Sotero",
                Email = "hello@sotero.com",
                Image = "https://....",
                Name = "Quipe sotero",
                PasswordHash = "HASH",
                Slug = "equipe-sotero"
            };

            var id = repo.Create(user);

            Console.WriteLine($"Usuario criado com o id: {id}");
        }

        public static void UpdateUser(UserRepository repo, int id)
        {
            var user = new UserEntity
            {
                Id = id,
                Bio = "Equipe | Sotero",
                Email = "hello@sotero.com",
                Image = "https://....",
                Name = "Equipe de suporte sotero",
                PasswordHash = "HASH",
                Slug = "euipe-sotero"
            };

            var alt = repo.Update(user);

            Console.WriteLine($"registro alterado: {alt}");

        }

        public static void DeleteUser(UserRepository repo, int id)
        {
            var del = repo.Delete(id);

            Console.WriteLine($"registro excluido: {del}");
        }
    }
}