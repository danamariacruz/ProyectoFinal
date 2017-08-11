using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        [Compare("Contraseña", ErrorMessage = "Por favor confirme su contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmarContraseña { get; set; }

    }
}