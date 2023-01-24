using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WebApiControlStock.Models
{
        [Table("Producto")]
        public class Producto
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [Column(TypeName = "varchar(50)")]
            public string Nombre { get; set; }

            [Required]
            public char LineaProducto { get; set; }

            public SqlMoney Precio { get; set; }

            public int CategoriaId { get; set; }
            [ForeignKey("CategoriaId")]
            public Categoria Categoria { get; set; }
        }
}

