using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class BaseTestObject<T> where T :struct
    {
        public T Id { get; set; }
        public decimal Amount { get; set; }
        protected abstract void Validate();
    }
}
