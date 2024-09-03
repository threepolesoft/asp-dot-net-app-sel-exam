using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Model.DbSet
{
    
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDelete { get; set; }
    }
}
