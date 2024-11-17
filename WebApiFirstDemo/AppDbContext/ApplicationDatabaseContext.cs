using Microsoft.EntityFrameworkCore;
using WebApiFirstDemo.Model;

namespace WebApiFirstDemo.ApplicationDbContext
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Book>Books { get; set; }   
        public DbSet<Author>Authors {  get; set; }  

    }
}
