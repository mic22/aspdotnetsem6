using System.Data.Entity;

namespace Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ZadanieContext")
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
     
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}