using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ITestObjectRepositry<T> where T:BaseTestObject
    {
        public void Add(T obj);
        public void Remove(T obj);
        public T Get(int id);
    }
}
