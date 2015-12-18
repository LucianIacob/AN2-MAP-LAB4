using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Dictionar;
using System.Collections;

namespace Lab4.Repository
{
    class Repository<T> where T : Lab4.Domain.IDObject
    {
        protected Dictionar<int, T> myDictionary = new Dictionar<int, T>();

        public bool add(T o)
        {
            return myDictionary.add(o.getID(), o);
        }
        public bool remove(int nrm)
        {
            return myDictionary.remove(nrm);
        }
        public bool update(T o)
        {
            return myDictionary.update(o.getID(), o);
        }
        public T find(int nrm)
        {
            return myDictionary.find(nrm);
        }
        public List<T> getList()
        {
            return myDictionary.myArray();
        }
    }
}
