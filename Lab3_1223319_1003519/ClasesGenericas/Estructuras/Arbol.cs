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

        public override void Delete(T value, Comparison<T> comparer)
        {
            try
            {
                Nodo<T> aux = Search(value, Raiz, comparer);
                if (aux.Derecha == null && aux.Izquierda == null)
                {
                    if (aux.Padre != null)
                    {
                        if (aux.Padre.Izquierda == aux)
                            aux.Padre.Izquierda = null;
                        else
                            aux.Padre.Derecha = null;
                    }
                    if (aux == Raiz)
                        Raiz = null;
                }
                else if (aux.Derecha != null && aux.Izquierda != null)
                {
                    Nodo<T> reemplazo = aux.Izquierda;
                    while (reemplazo.Derecha != null)
                    {
                        reemplazo = reemplazo.Derecha;
                    }
                    Delete(reemplazo.Valor, comparer);
                    if (aux.Padre != null)
                    {
                        if (aux.Padre.Izquierda == aux)
                        {
                            aux.Padre.Izquierda = reemplazo;
                        }
                        else
                        {
                            aux.Padre.Derecha = reemplazo;
                        }
                    }
                    reemplazo.Padre = aux.Padre;
                    aux.Izquierda.Padre = reemplazo;
                    aux.Derecha.Padre = reemplazo;
                    reemplazo.Izquierda = aux.Izquierda;
                    reemplazo.Derecha = reemplazo.Derecha;
                    if (aux == Raiz)
                        Raiz = reemplazo;
                }
                else
                {
                    if (aux.Padre != null)
                    {
                        if (aux.Padre.Izquierda == aux)
                        {
                            if (aux.Izquierda != null)
                            {
                                aux.Padre.Izquierda = aux.Izquierda;
                                aux.Izquierda.Padre = aux.Padre;
                            }
                            else
                            {
                                aux.Padre.Izquierda = aux.Derecha;
                                aux.Derecha.Padre = aux.Padre;
                            }
                        }
                        else
                        {
                            if (aux.Izquierda != null)
                            {
                                aux.Padre.Derecha = aux.Izquierda;
                                aux.Izquierda.Padre = aux.Padre;
                            }
                            else
                            {
                                aux.Padre.Derecha = aux.Derecha;
                                aux.Derecha.Padre = aux.Padre;
                            }
                        }

                    }
                    if (aux == Raiz)
                    {
                        if (aux.Izquierda != null)
                        {
                            Raiz = aux.Izquierda;
                        }
                        else
                        {
                            Raiz = aux.Derecha;
                        }
                    }
                }
                Count--;
            }
            catch
            {
            }
        }

        public T Search(T value, Comparison<T> comparer)
        {
            Nodo<T> result = Search(value, Raiz, comparer);
            if (result != null)
                return result.Valor;
            else
                return default(T);
        }

        protected override Nodo<T> Search(T value, Nodo<T> position, Comparison<T> comparer)
        {
            if (position != null)
            {
                if (comparer.Invoke(value, position.Valor) == 0)
                    return position;
                else
                {
                    if (comparer.Invoke(value, position.Valor) < 0)
                        return Search(value, position.Izquierda, comparer);
                    else
                        return Search(value, position.Derecha, comparer);
                }
            }
            else
                return new Nodo<T>();
        }

        public void Clear()
        {
            Raiz = null;
            Count = 0;
        }

        private void Inorden(Nodo<T> position, List<T> recorrido)
        {
            if (position.Izquierda != null)
                Inorden(position.Izquierda, recorrido);
            recorrido.Add(position.Valor);
            if (position.Derecha != null)
                Inorden(position.Derecha, recorrido);
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> recorrido = new List<T>();
            if (Raiz != null)
                Inorden(Raiz, recorrido);
            while(recorrido.Count > 0)
            {
                yield return recorrido[0];
                recorrido.Remove(recorrido[0]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
