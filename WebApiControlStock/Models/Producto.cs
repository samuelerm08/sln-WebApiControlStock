using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using WebApiControlStock.Validations;
using System.Collections.Generic;

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
        [Column(TypeName = "char(1)")]
        [SoloHySValidation]
        public string LineaProducto { get; set; }

        [Column(TypeName = "money")]
        [MayorACeroValidation]
        public double Precio { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}

