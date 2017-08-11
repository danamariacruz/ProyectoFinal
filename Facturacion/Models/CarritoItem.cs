using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Facturacion.Models
{
    public class CarritoItem
    {
        private Productos _productos;
        private int _cantidad;
        
        public Productos Items
        {
            get { return _productos; }
            set { _productos = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public CarritoItem()
        {

        }

        public CarritoItem(Productos producto, int cantidad)
        {
            this.Items = producto;
            this.Cantidad = cantidad;
        }
    }
}