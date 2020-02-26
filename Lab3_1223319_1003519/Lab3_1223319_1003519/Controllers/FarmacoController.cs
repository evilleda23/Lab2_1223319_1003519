using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3_1223319_1003519.Helpers;
using Lab3_1223319_1003519.Models;

namespace Lab3_1223319_1003519.Controllers
{
    public class FarmacoController : Controller
    {
        // GET: Farmaco
        public ActionResult Index()
        {
            Storage.Instance.Indice.Add(new Farmaco { ID = 1, Nombre = "Paracetamol" });
            return View(Storage.Instance.Indice);
        }

        // GET: Farmaco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Farmaco/Create
        public ActionResult Create()
        {
            return View("Pedido");
        }

        // POST: Farmaco/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Farmaco/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Farmaco/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Farmaco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Farmaco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
