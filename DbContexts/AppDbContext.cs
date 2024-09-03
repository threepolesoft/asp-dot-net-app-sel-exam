using Microsoft.EntityFrameworkCore;
using WebApiApp.Model.DbSet;

namespace WebApiApp.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        // Entity
        public DbSet<UserInfo> userInfo { get; set; }
    }
}
