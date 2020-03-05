using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1223319_1003519.Models
{
    public class SubirArchivo
    {
        public String Confirmacion { get; set; }
        public Exception Error { get; set; }
        public  void SubirAr (String ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.Confirmacion = "Archivo Actualizado"; 
            }
            catch (Exception ex)
            {

                this.Error = ex;
            }
        }
    }
}