using e_commerce.Entity;
using e_commerce.Repository;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.ApplicationContextName
{
    public class ApplicationContext:DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsyncs()
        {
            return await base.SaveChangesAsync();
        }
        public DbSet<ProductEntity> Products { get; set; }

    }
}
