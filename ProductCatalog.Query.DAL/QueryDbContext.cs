using Microsoft.EntityFrameworkCore;
using ProductCatalog.Query.DAL.DataModel;

namespace ProductCatalog.Query.DAL
{
    public class QueryDbContext : DbContext
    {

        public QueryDbContext(DbContextOptions<QueryDbContext> dbContextOptions)
           : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}