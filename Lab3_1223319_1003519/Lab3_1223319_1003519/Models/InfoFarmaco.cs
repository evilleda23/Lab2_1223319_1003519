using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1223319_1003519.Models
{
    public class InfoFarmaco
    {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Productora { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }

    }   
}