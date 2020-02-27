using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1223319_1003519.Models
{
    public class Farmaco
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public static Comparison<Farmaco> CompararNombre = delegate (Farmaco f1, Farmaco f2)
        {
            return f1.Nombre.ToLower().CompareTo(f2.Nombre.ToLower());
        };

        public static Comparison<Farmaco> CompararID = delegate (Farmaco f1, Farmaco f2)
        {
            return f1.ID.CompareTo(f2.ID);
        };
    }
}