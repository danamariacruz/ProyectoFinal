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
    public class ClientesController : Controller
    {
         ProyectoFinalDB db = new ProyectoFinalDB();

        
        public ActionResult Index()
        {
            
            return View(db.cliente.ToList());
        }
        //------------------------------------------------------------------------------------------------  
        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            Clientes cli = new Clientes();
            cli.Nombre = cliente.Nombre;
            cli.Apellido = cliente.Apellido;
            cli.Correo = cliente.Correo;
            cli.Direccion = cliente.Direccion;
            cli.Telefono = cliente.Telefono;

            db.cliente.Add(cli);
            db.SaveChanges();
            return View();
               
        }
        //------------------------------------------------------------------------------------------------  

        public ActionResult Delete(int id)
        {
            var item = db.cliente.Where(x => x.ClienteId == id).First();
            db.cliente.Remove(item);
            db.SaveChanges();

            var back = db.cliente.ToList();

            return View("Index", back);
        }

//------------------------------------------------------------------------------------------------      

        public ActionResult Edit(int id)
        {
            var item = db.cliente.FirstOrDefault(x => x.ClienteId == id);
            return View(item);
        }

        [HttpPost]
       public ActionResult Edit(int id, FormCollection collection)
       {
            Clientes cliente = db.cliente.FirstOrDefault(x => x.ClienteId == id);
            UpdateModel(cliente);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        

    }

}

