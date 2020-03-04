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
            //if (Storage.Instance.PrimeraSesion)
            //{
            //    CargarArchivo();
            //    Storage.Instance.PrimeraSesion = false;
            //}
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
            return View("Pedido");
        }
        [HttpPost]
        public ActionResult AgregarProducto(int id, FormCollection collection)
        {
            int cant = int.Parse(collection["cant"]);
            double total = 0;
            InfoFarmaco nuevo = new InfoFarmaco();
            using (FileStream archivo = new FileStream("C://Users//estua//source//repos//Esjosev25//Lab2_1223319_1003519//Lab3_1223319_1003519//Farmacoss.csv", FileMode.Open))
            {

                using (StreamReader lector = new StreamReader(archivo))
                {
                    while (!lector.EndOfStream)
                    {
                        string texto = lector.ReadLine();
                        if (id == Int32.Parse(texto.Substring(0, texto.IndexOf(";"))))
                        {


                            nuevo.ID = Int32.Parse(texto.Substring(0, texto.IndexOf(";")));
                            texto = texto.Remove(0, texto.IndexOf(";") + 1);
                            nuevo.Nombre = texto.Substring(0, texto.IndexOf(";"));
                            texto = texto.Remove(0, texto.IndexOf(";") + 1);
                            nuevo.Descripcion = texto.Substring(0, texto.IndexOf(";"));
                            texto = texto.Remove(0, texto.IndexOf(";") + 1);
                            nuevo.CasaProductora = texto.Substring(0, texto.IndexOf(";"));
                            texto = texto.Remove(0, texto.IndexOf(";") + 1);
                            nuevo.Precio = double.Parse(texto.Substring(0, texto.IndexOf(";")));
                            texto = texto.Remove(0, texto.IndexOf(";") + 1);
                            nuevo.Existencia = int.Parse(texto);
                          

                        }
                        

                    };

                    
                }
            }
            if (cant < nuevo.Existencia)
                nuevo.Existencia -= cant;

            total = nuevo.Precio * cant;
            return View("Pedido");
        }
        public ActionResult Reabastecer(int id)
        {
            string[] texto = Storage.Instance.Farmacos.Split('\r', '\n');
            try
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i] != "")
                    {
                        if (id == Int32.Parse(texto[i].Substring(0, 1)))
                        {
                            string aux = texto[i];
                            string aux2 = "";
                            //InfoFarmaco nuevo = new InfoFarmaco();
                            //nuevo.ID = Int32.Parse(texto[i].Substring(0, texto[i].IndexOf(";")));
                            //texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                            //nuevo.Nombre = texto[i].Substring(0, texto[i].IndexOf(";"));
                            //texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                            //nuevo.Descripcion = texto[i].Substring(0, texto[i].IndexOf(";"));
                            //texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                            //nuevo.CasaProductora = texto[i].Substring(0, texto[i].IndexOf(";"));
                            //texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                            //nuevo.Precio = double.Parse(texto[i].Substring(0, texto[i].IndexOf(";")));
                            //texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                            //nuevo.Existencia = int.Parse(texto[i]);
                            while (aux.Contains(";"))
                            {
                                aux2 += aux.Substring(0, aux.IndexOf(";") + 1);
                                aux = aux.Remove(0, aux.IndexOf(";") + 1);
                            }
                            if (Int32.Parse(aux) == 0)
                            {
                                Random rnd = new Random();
                                aux2 += rnd.Next(1, 15).ToString();
                                texto[i] = aux2;
                            }
                        }
                    }
                }
                Sobreescribir(texto);
            }
            catch
            {
            }


            return RedirectToAction("Index");
            }
         

        //Se debe cambiar la ruta del archivo para que no ocurran errores en la carga.
        [HttpPost]
        public ActionResult AbrirArchivo(HttpPostedFileBase file)
        {
            try
            {
                using (StreamReader lector = new StreamReader(file.InputStream))
                {
                    Storage.Instance.Farmacos = lector.ReadToEnd();
                }
                string[] texto = Storage.Instance.Farmacos.Split('\r', '\n');
                Storage.Instance.Indice.Clear();
                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i] != "")
                    {
                        Farmaco nuevo = new Farmaco
                        {
                            ID = Int32.Parse(texto[i].Substring(0, texto[i].IndexOf(";")))
                        };
                        texto[i] = texto[i].Remove(0, texto[i].IndexOf(";") + 1);
                        nuevo.Nombre = texto[i].Substring(0, texto[i].IndexOf(";"));
                        Storage.Instance.Indice.Add(nuevo, Farmaco.CompararNombre);
                    }
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GuardarArchivo(HttpPostedFileBase file)
        {
            //try
            //{
            //// StreamWriter escritor = new StreamWriter(file.InputStream);
            //    escritor.Flush();
            //    escritor.Write(Storage.Instance.Farmacos);
            //    escritor.Close();
            //}
            //catch
            //{
            //}
            return RedirectToAction("Index");
        }

        public void Sobreescribir(string[] text)
        {
            Storage.Instance.Farmacos = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != "")
                {
                    Storage.Instance.Farmacos += text[i];
                    if (i != text.Length - 1)
                        Storage.Instance.Farmacos += "\r\n";
                }
            }
        }
    }
}
