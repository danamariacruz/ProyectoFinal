using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Facturacion.Models
{
    public class ListaVenta
    {
        [Key]
        public int ID { get; set; }

        public int VentaId { get; set; }

        public int ProductoID { get; set; }

        public virtual Ventas Ventas { get; set; }

        public virtual Productos Productos { get; set; }

        public int Cantidad { get; set; }

        public float Total { get; set; }

    }
}