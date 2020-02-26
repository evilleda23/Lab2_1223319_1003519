    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Interfaces
{
    public abstract class EstructuraDatos<T>
    {
        protected abstract void Insert(T value);
        public abstract void Delete(int position);
        public abstract T Get(int position);
        public abstract void Set(T value, int position);
    }
}
