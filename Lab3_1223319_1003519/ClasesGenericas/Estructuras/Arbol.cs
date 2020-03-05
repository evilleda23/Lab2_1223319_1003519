using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClasesGenericas.Interfaces;

namespace ClasesGenericas.Estructuras
{
    public class Arbol<IComparable> : EstructuraNoLineal<IComparable>, IEnumerable<IComparable>
    {
        private Nodo<IComparable> Raiz { get; set; }
        public int Count { get; set; } = 0;

        public void Add(IComparable value, Comparison<IComparable> comparer)
        {
            Count++;
            if (Raiz == null)
            {
                Raiz = new Nodo<IComparable>
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

        protected override void Insert(IComparable value, Nodo<IComparable> position, Comparison<IComparable> comparer)
        {
            if (comparer.Invoke(value, position.Valor) > 0)
            {
                if (position.Derecha == null)
                {
                    position.Derecha = new Nodo<IComparable>
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
                    position.Izquierda = new Nodo<IComparable>
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

        public override IComparable Remove(IComparable value, Comparison<IComparable> comparer)
        {
            try
            {
                Nodo<IComparable> aux = Search(value, Raiz, comparer);
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
                    Nodo<IComparable> reemplazo = aux.Izquierda;
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
                    else
                    {
                        if (aux.Izquierda != null)
                        {
                            aux.Izquierda.Padre = aux.Padre;
                        }
                        else
                        {
                            aux.Derecha.Padre = aux.Padre;
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
                return aux.Valor;
            }
            catch
            {
                return default(IComparable);
            }
        }

        public override void Delete(IComparable value, Comparison<IComparable> comparer)
        {
            Remove(value, comparer);
        }

        public IComparable Search(IComparable value, Comparison<IComparable> comparer)
        {
            Nodo<IComparable> result = Search(value, Raiz, comparer);
            if (result != null)
                return result.Valor;
            else
                return default(IComparable);
        }

        protected override Nodo<IComparable> Search(IComparable value, Nodo<IComparable> position, Comparison<IComparable> comparer)
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
                return new Nodo<IComparable>();
        }

        public void Clear()
        {
            Raiz = null;
            Count = 0;
        }

        private void Inorden(Nodo<IComparable> position, List<IComparable> recorrido)
        {
            if (position.Izquierda != null)
                Inorden(position.Izquierda, recorrido);
            recorrido.Add(position.Valor);
            if (position.Derecha != null)
                Inorden(position.Derecha, recorrido);
        }

        public IEnumerator<IComparable> GetEnumerator()
        {
            List<IComparable> recorrido = new List<IComparable>();
            if (Raiz != null)
            {
                Inorden(Raiz, recorrido);
                recorrido.Sort();
            }
            while (recorrido.Count > 0)
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
