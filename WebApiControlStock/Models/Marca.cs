using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiControlStock.Models
{
    [Table("Marca")]
    public class Marca
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
