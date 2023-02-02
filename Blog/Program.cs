using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions; // UTILIZA ESSA EXTENSÃO PARA PERFOMAR NO DAPPER FICAR MAIS SIMPLES AS BUSCAS E INSERTS USANDO O GET , GET ALL , INSERT ETC...
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Blog
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;Encrypt=True";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                //WriteRole(connection);

                //ReadUsers(connection);
                //ReadUser(connection);
                //WriteUser(connection);
                //UpdateUser(connection);
                //DeleteUser(connection);
                // ReadCategory(connection);
                GetRolesAndUsers(connection);
            }

        }

        #region USERS
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var usersList = repository.GetAll();

            foreach (var item in usersList)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = repository.Get(1);
            if (user != null)
            {
                Console.WriteLine(user.Name);
            }
        }

        public static void WriteUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = new User()
            {
                Bio = "Biografia",
                Email = "Doug2@gmail.com",
                Image = "DougIMG.PNG",
                Name = "Doug Carvalho",
                PasswordHash = "AUSHDUASD*&!@*#UAHSUD",
                Slug = "SLUG2"
            };
            repository.Create(user);
            Console.WriteLine(user.Name);

        }

        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = new User()
            {
                Id = 2,
                Bio = "Biografia",
                Email = "Douguin@gmail.com",
                Image = "DougIMG.PNG",
                Name = "Doug Carvalho",
                PasswordHash = "AUSHDUASD*&!@*#UAHSUD",
                Slug = "SLUGuer Updated"
            };

            repository.Update(user);
            Console.WriteLine("Atualizado com sucesso");

        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = repository.Get(2);
            repository.Delete(user);
            Console.WriteLine("Excluido com sucesso");
        }

        #endregion

        #region ROLES
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roleList = repository.GetAll();

            foreach (var item in roleList)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadRole(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var role = repository.Get(1);
            if (role != null)
            {
                Console.WriteLine(role.Name);
            }
        }

        public static void WriteRole(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var role = new Role()
            {
                Name = "Administrator",
                Slug = "administrator"
            };
            repository.Create(role);
            Console.WriteLine(role.Name);

        }

        public static void UpdateRole(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var role = new Role()
            {
                Id = 2,
                Name = "Administrator 2",
                Slug = "administrator 2"
            };

            repository.Update(role);
            Console.WriteLine("Atualizado com sucesso");

        }

        public static void DeleteRole(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var role = repository.Get(2);
            repository.Delete(role);
            Console.WriteLine("Excluido com sucesso");
        }
        #endregion

        #region Category
        public static void ReadAllCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var categoryList = repository.GetAll();

            foreach (var item in categoryList)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var category = repository.Get(1);
            if (category != null)
            {
                Console.WriteLine(category.Name);
            }
        }

        public static void WriteCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var category = new Category()
            {
                Name = "Administrator",
                Slug = "administrator"
            };
            repository.Create(category);
            Console.WriteLine(category.Name);

        }

        public static void UpdateCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var role = new Category()
            {
                Id = 2,
                Name = "Administrator 2",
                Slug = "administrator 2"
            };

            repository.Update(role);
            Console.WriteLine("Atualizado com sucesso");

        }

        public static void DeleteCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var role = repository.Get(2);
            repository.Delete(role);
            Console.WriteLine("Excluido com sucesso");
        }
        #endregion

        public static void  GetRolesAndUsers(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            repository.GetRolesAndUsers();
        }
    }
}
