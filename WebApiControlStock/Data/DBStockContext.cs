using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApiControlStock.Models;

namespace WebApiControlStock.Data
{
    public class DBStockContext : DbContext
    {
        public DBStockContext(DbContextOptions<DBStockContext> options) : base(options){}

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }        
    }
}

