using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="T">target object type</typeparam>
    /// <typeparam name="Y">object id type</typeparam>
    public interface ITestObjectRepositry<T, Y>
        where T : BaseTestObject<Y>
        where Y : struct
    {
        public void Add(T obj);
        public void Remove(T obj);
        public T Get(Y id);
    }
}
