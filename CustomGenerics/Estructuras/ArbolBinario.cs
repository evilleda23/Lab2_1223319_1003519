using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGenerics.Interfaces;
using System.Collections;

namespace CustomGenerics.Estructuras
{
    public class ArbolBinario<T>: EstructuraDatos<T>, IEnumerable<T>
    {
        private Nodo<T> Raiz { get; set; }
        public int Count { get; set; } = 0;

        protected override void Insert(T value)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo<T>
                {
                    Valor = value,
                    Izq = null,
                    Der = null
                };
            }
            else
            {
                var posicion = Raiz;
                
                if(posicion.Valor<value)
                while (posicion.Siguiente != null)
                {
                    posicion = posicion.Siguiente;
                }
                posicion.Der = new Nodo<T>
                {
                    Valor = value,
                    Siguiente = null,
                    Anterior = posicion
                };
            }
            Count++;
        }
        public override void Delete(int position)
        {
            throw new NotImplementedException();
        }

        public override T Get(int position)
        {
            throw new NotImplementedException();
        }

        public override void Set(T value, int position)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

   
    }
}
