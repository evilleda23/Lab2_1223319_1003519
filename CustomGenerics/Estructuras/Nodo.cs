using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Estructuras
{
    public class Nodo<T>
    {
        public Nodo<T> Izq { get; set; }
        public Nodo<T> Der { get; set; }
        public T Valor { get; set; }

    }
}   
