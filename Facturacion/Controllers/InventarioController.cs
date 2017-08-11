
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class InventarioController : Controller
    {

        ProyectoFinalDB db = new ProyectoFinalDB();
        
        public ActionResult Index()
        {
            return View(db.productos.ToList());
        }
        //------------------------------------------------------------------------------------------------ 

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Productos productos)
        {

            Productos producto = new Productos();
            producto.Nombre = productos.Nombre;
            producto.Descripcion = productos.Descripcion;
            producto.PrecioUnidad = productos.PrecioUnidad;
            producto.Disponibilidad = productos.Disponibilidad;
            producto.Vendedores = productos.Vendedores;
            producto.Categoria = productos.Categoria;

            db.productos.Add(producto);
            db.SaveChanges();
            return View();
        }
        //------------------------------------------------------------------------------------------------ 
        public ActionResult Edit(int id)
        {
            var item = db.productos.FirstOrDefault(x => x.ProductoID == id);
            return View(item);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Productos producto = db.productos.FirstOrDefault(x => x.ProductoID == id);
            UpdateModel(producto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------------------------------------ 
        public ActionResult Delete(int id)
        {

            var item = db.productos.Where(x => x.ProductoID == id).First();
            db.productos.Remove(item);
            db.SaveChanges();

            var back = db.productos.ToList();

            return View("Index", back);
        }
        //------------------------------------------------------------------------------------------------ 
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