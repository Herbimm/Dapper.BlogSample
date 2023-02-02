using Blog.Models;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        #region Constructor
        public RoleRepository(SqlConnection connection)
            => _connection = connection;
        #endregion
        public IEnumerable<Role> GetAll()
             => _connection.GetAll<Role>();

        public Role Get(int id)
             => _connection.Get<Role>(id);

        public void Create(Role role)
             => _connection.Insert<Role>(role);

        public void Update(Role role)
             => _connection.Update<Role>(role);

        public void Delete(Role role)
             => _connection.Delete<Role>(role);
    }
}
