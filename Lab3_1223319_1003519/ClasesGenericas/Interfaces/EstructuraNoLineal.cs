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
        protected abstract void Delete(T value, Nodo<T> position, Comparison<T> comparer);
    }
}
