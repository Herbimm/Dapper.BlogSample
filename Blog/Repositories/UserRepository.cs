using Blog.Models;
using System.Data.SqlClient;
using System;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)         
            => connection = _connection;        

        public IEnumerable<User> GetAll()        
             => _connection.GetAll<User>();

        public User Get(int id)
             => _connection.Get<User>(id);

        public void Create(User user)
             => _connection.Insert<User>(user);

        public void Update(User user)
             => _connection.Update<User>(user);

        public void Delete(User user)
             => _connection.Delete<User>(user);

    }
}
