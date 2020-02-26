using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClasesGenericas.Interfaces;

namespace ClasesGenericas.Estructuras
{
    public class Arbol<T> : EstructuraNoLineal<T>, IEnumerable<T>
    {
        private Nodo<T> Raiz { get; set; }
        public int Count { get; set; } = 0;

        public void Add(T value, Comparison<T> comparer)
        {
            Count++;
            if (Raiz == null)
            {
                Raiz = new Nodo<T>
                {
                    Valor = value,
                    Padre = null,
                    Izquierda = null,
                    Derecha = null
                };
            }
            else
                Insert(value, Raiz, comparer);
        }

        protected override void Insert(T value, Nodo<T> position, Comparison<T> comparer)
        {
            if (comparer.Invoke(value, position.Valor) > 0)
            {
                if (position.Derecha == null)
                {
                    position.Derecha = new Nodo<T>
                    {
                        Valor = value,
                        Padre = position,
                        Izquierda = null,
                        Derecha = null
                    };
                }
                else
                    Insert(value, position.Derecha, comparer);
            }
            else
            {
                if (position.Izquierda == null)
                {
                    position.Izquierda = new Nodo<T>
                    {
                        Valor = value,
                        Padre = position,
                        Izquierda = null,
                        Derecha = null
                    };
                }
                else
                    Insert(value, position.Izquierda, comparer);
            }
        }

        protected override void Delete(T value, Nodo<T> position, Comparison<T> comparer)
        {
            if (value.Equals(Raiz))
            {
                
            }
            /*Nodo<T> aux = First;
            try
            {
                for (int i = 0; i < position; i++)
                {
                    aux = aux.Siguiente;
                }
                if (aux == First)
                {
                    First = aux.Siguiente;
                }
                if (aux.Anterior != null)
                {
                    aux.Anterior.Siguiente = aux.Siguiente;
                }
                if (aux.Siguiente != null)
                {
                    aux.Siguiente.Anterior = aux.Anterior;
                }
                Count--;
            }
            catch
            {
            }*/
        }

        public void Clear()
        {
            Raiz = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> aux = Raiz;
            while (aux != null)
            {
                yield return aux.Valor;
                aux = aux.Derecha;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
