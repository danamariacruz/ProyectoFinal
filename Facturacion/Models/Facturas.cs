using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class Facturas
    {
        [Key]
        public int FacturaID { get; set; }

        public int VentasID { get; set; }

        public int ListaVentaId { get; set; }

        public int ClienteID { get; set; }

        public virtual Ventas Ventas { get; set; }

        public virtual ListaVenta ListaVenta { get; set; }
        
        public virtual Clientes Clientes { get; set; }

       
    }
}