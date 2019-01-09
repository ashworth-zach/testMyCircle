using Microsoft.EntityFrameworkCore;
 
namespace myCircle.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<users> users { get; set; }
        public DbSet<circles> circles { get; set; }
        public DbSet<messagelikes> messagelikes { get; set; }
        public DbSet<messages> messages { get; set; }
        public DbSet<images> images { get; set; }

    }
}