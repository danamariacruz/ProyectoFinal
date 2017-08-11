using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class Vendedores
    {
        [Key]
        public int VendedorID { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }

        public string Telefono { get; set; }

    }
}