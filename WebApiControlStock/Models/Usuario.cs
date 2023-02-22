using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WebApiControlStock.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Direccion { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int DNI { get; set; }        
    }
}
