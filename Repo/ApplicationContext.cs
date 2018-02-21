using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Data.Maps;

namespace test.Repo
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {  
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            base.OnModelCreating(modelBuilder);  
            new UserMap(modelBuilder.Entity<User>()); 
            new ProductMap(modelBuilder.Entity<Product>());
            new HistMap(modelBuilder.Entity<Hist>());
            new PrivilegeMap(modelBuilder.Entity<Privilege>());
            new G_TableMap(modelBuilder.Entity<G_Table>());
        }  
    }
}