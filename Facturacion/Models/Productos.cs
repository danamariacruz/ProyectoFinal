using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        [Required]
        public double PrecioUnidad { get; set; }
       
        public double Disponibilidad { get; set; }

        public int VendedorID { get; set; }

        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Vendedores Vendedores { get; set; }

    }
}