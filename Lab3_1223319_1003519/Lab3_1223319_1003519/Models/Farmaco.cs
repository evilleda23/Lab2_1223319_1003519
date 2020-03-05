using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_1223319_1003519.Models
{
    public class Farmaco : IComparable
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public static Comparison<Farmaco> CompararNombre = delegate (Farmaco f1, Farmaco f2)
        {
            return f1.Nombre.ToLower().CompareTo(f2.Nombre.ToLower());
        };

        public static Comparison<Farmaco> CompararID = delegate (Farmaco f1, Farmaco f2)
        {
            return f1.ID.CompareTo(f2.ID);
        };

        public static Comparison<Farmaco> CompararCantidad = delegate (Farmaco f1, Farmaco f2)
        {
            return f1.Cantidad.CompareTo(f2.Cantidad);
        };

        public int CompareTo(object obj)
        {
            try
            {
                return this.ID.CompareTo(((Farmaco)obj).ID);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}