
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class ProductosController : Controller
    {
        ProyectoFinalDB db = new ProyectoFinalDB();

        public ActionResult Index()
        {
            return View(db.productos.ToList());
        }

        public ActionResult Busqueda(string Nombre)
        {
            var filtro = from s in db.productos select s;
            if (!String.IsNullOrEmpty(Nombre))
            {
                filtro = filtro.Where(j => j.Nombre.Contains(Nombre));
            }
            return View("Index",filtro);
        }
    }
}