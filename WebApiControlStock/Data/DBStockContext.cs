using Microsoft.EntityFrameworkCore;
using WebApiControlStock.Models;

namespace WebApiControlStock.Data
{
    public class DBStockContext : DbContext
    {
        public DBStockContext(DbContextOptions<DBStockContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }


    }
}
