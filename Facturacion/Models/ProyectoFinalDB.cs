
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class ProyectoFinalDB : DbContext
    {
        public DbSet<Vendedores> vendedor {get; set;}
        public DbSet<Clientes> cliente { get; set; }
        public DbSet<Facturas> facturas { get; set; }
        public DbSet<ListaVenta> listaVenta { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Usuario> usuario { get; set; }

     
    }
}