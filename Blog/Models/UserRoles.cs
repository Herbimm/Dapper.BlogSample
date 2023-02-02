using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("UserRole")]
    public class UserRoles
    {        
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
