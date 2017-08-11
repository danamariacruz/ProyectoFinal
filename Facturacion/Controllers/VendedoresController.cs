
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
    public class VendedoresController : Controller
    {
        ProyectoFinalDB db = new ProyectoFinalDB();
        
        public ActionResult Index()
        {

            return View(db.vendedor.ToList());
        }
        //------------------------------------------------------------------------------------------------  
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendedores vendedores)
        {
            Vendedores vendedor = new Vendedores();
            vendedor.Nombre = vendedores.Nombre;
            vendedor.Correo = vendedores.Correo;
            vendedor.Direccion = vendedores.Direccion;
            vendedor.Telefono = vendedores.Telefono;

            db.vendedor.Add(vendedor);
            db.SaveChanges();
            return View();

        }
        //------------------------------------------------------------------------------------------------  

        public ActionResult Delete(int id)
        {
            var item = db.vendedor.Where(x => x.VendedorID == id).First();
            db.vendedor.Remove(item);
            db.SaveChanges();

            var back = db.vendedor.ToList();

            return View("Index", back);
        }

        //------------------------------------------------------------------------------------------------      

        public ActionResult Edit(int id)
        {
            var item = db.vendedor.FirstOrDefault(x => x.VendedorID == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Vendedores vendedor = db.vendedor.FirstOrDefault(x => x.VendedorID == id);
            UpdateModel(vendedor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}