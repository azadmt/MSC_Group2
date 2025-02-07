using InventoryMnagement.Worker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMnagement.Worker.DataAccess
{
    internal class InventoryManagementDbContext: DbContext
    {

        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> dbContextOptions)
           : base(dbContextOptions)
        {

        }
        public DbSet<Stock> stocks { get; set; }
    }
}
