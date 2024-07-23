using e_commerce.Entity;
using e_commerce.Repository;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.ApplicationContextName
{
    public interface IApplicationContext
    {
        DbSet<ProductEntity> Products { get; set; }

        Task<int> SaveChangesAsyncs();

    }
}
