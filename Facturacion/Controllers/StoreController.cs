
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Facturacion.Controllers
{
    public class StoreController : Controller
    {
        ProyectoFinalDB db = new ProyectoFinalDB();
        
        //metodo que devuelve la lista de categoria
        public ActionResult Index()
        {
            var result = db.categoria.ToList();

            return View(result);
        }

        
        public ActionResult Buscar(string Categoria)
        {
            var Category = db.categoria.Include("Items")
                .Single(c => c.Nombre == Categoria);
            return View(Category);
        }

        // devuelve los detalles de los items
        public ActionResult Details(int id)
        {
            var item = db.productos.Include("Categoria").Where(x => x.ProductoID == id).FirstOrDefault();
            
            return View(item);
        }

        public ActionResult Ventas()
        {
            var result = db.ventas.ToList();

            return View(result);
        }

        public ActionResult ArticuloVenta(int ventaId)
        {
            try
            {
                var result = (from articulo in db.listaVenta
                              where articulo.VentaId == ventaId
                              select articulo).ToList();

                return View(result);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Factura(int ventaId)
        {
            try
            {
                var result = (from articulo in db.listaVenta
                              where articulo.VentaId == ventaId
                              select articulo).ToList();

                return View(result);
            }
            catch
            {
                return View();
            }
        }

    }
}