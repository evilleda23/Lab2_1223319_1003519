using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3_1223319_1003519.Helpers;
using Lab3_1223319_1003519.Models;
using System.IO;
using ClasesGenericas.Estructuras;

namespace Lab3_1223319_1003519.Controllers
{
    public class FarmacoController : Controller
    {
        // GET: Farmaco
        public ActionResult Index()
        {
            if (Storage.Instance.PrimeraSesion)
            {
                CargarArchivo();
                Storage.Instance.PrimeraSesion = false;
            }
            return View(Storage.Instance.Indice);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string name = collection["search"];
            List<Farmaco> resultados = new List<Farmaco>
            {
                Storage.Instance.Indice.Search(new Farmaco { Nombre = name }, Farmaco.CompararNombre)
            };
            return View(resultados);
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

        public ActionResult AgregarProducto(int id)
        {
            return View();
        }

        public ActionResult Reabastecer()
        {
            return View();
        }

        //Se debe cambiar la ruta del archivo para que no ocurran errores en la carga.
        private void CargarArchivo()
        {
            try
            {
                using (FileStream archivo = new FileStream("D://Users//Luis//Documents//Estructuras de Datos I//Lab3_1223319_1003519//Lab3_1223319_1003519//Farmacos.csv", FileMode.Open))
                {
                    using (StreamReader lector = new StreamReader(archivo))
                    {
                        while (!lector.EndOfStream)
                        {
                            string texto = lector.ReadLine();
                            Farmaco nuevo = new Farmaco
                            {
                                ID = Int32.Parse(texto.Substring(0, texto.IndexOf(",")))
                            };
                            texto = texto.Remove(0, texto.IndexOf(",") + 1);
                            nuevo.Nombre = texto.Substring(0, texto.IndexOf(","));
                            Storage.Instance.Indice.Add(nuevo, Farmaco.CompararNombre);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
