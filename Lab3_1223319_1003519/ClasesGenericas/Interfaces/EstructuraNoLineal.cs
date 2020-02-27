using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesGenericas.Estructuras;

namespace ClasesGenericas.Interfaces
{
    public abstract class EstructuraNoLineal<T>
    {
        protected abstract void Insert(T value, Nodo<T> position, Comparison<T> comparer);
        public abstract void Delete(T value, Comparison<T> comparer);
        protected abstract Nodo<T> Search(T value, Nodo<T> position, Comparison<T> comparer);
    }
}
