using Lab4.IDictionar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Dictionar
{
    [Serializable()]
    public class Dictionar<K, V> : IDictionar<K, V> where K : IComparable<K>
    {
        [Serializable()]
        public class Pereche: IComparable<Pereche>
        {
            public K cheie;
            public V valoare;
            public Pereche(K cheie, V valoare)
            {
                this.cheie = cheie;
                this.valoare = valoare;
            }
            public int CompareTo(Pereche o)
            {
                return this.cheie.CompareTo(o.cheie);
            }
        }

        private LinkedList<Pereche> myList = new LinkedList<Pereche>();

        public List<V> myArray()
        {
            List<V> myArray = new List<V>();
            LinkedList<Pereche>.Enumerator itr = myList.GetEnumerator();
            while (itr.MoveNext())
            {
                myArray.Add(itr.Current.valoare);
            }
            return myArray;
        }

        public LinkedList<Pereche>.Enumerator getIterator()     {   return myList.GetEnumerator();  }

        public Boolean add(K key, V valoare)
        {
            Pereche p = new Pereche(key, valoare);
            LinkedList<Pereche>.Enumerator iterator = getIterator();
            
            if (myList.Count == 0) myList.AddFirst(p);
            else
            {
                LinkedList<Pereche>.Enumerator itr = myList.GetEnumerator();
                bool gasit = false;
                while (itr.MoveNext())
                {
                    if (itr.Current.CompareTo(p) > 0)
                    {
                        gasit = true;
                        break;
                    }
                }
                LinkedListNode<Pereche> after = myList.Find(itr.Current);
                if (gasit == true) myList.AddBefore(after, p);
                else               myList.AddAfter(after, p);
            }
            return true;
        }

        public Boolean update(K key, V valoare)
        {
            Pereche p = new Pereche(key, valoare);
            LinkedList<Pereche>.Enumerator iterator = myList.GetEnumerator();
            while (iterator.MoveNext())
                if (iterator.Current.CompareTo(p) == 0) break;
            myList.AddAfter(myList.Find(iterator.Current), p);
            myList.Remove(myList.Find(iterator.Current));
            return true;
        }

        public Boolean remove(K key)
        {
            LinkedList<Pereche>.Enumerator iterator = myList.GetEnumerator();
            while (iterator.MoveNext())
                if (iterator.Current.cheie.CompareTo(key) == 0) break;
            LinkedListNode<Pereche> nod = myList.Find(iterator.Current);
            myList.Remove(nod);
            return true;
        }

        public V find(K key)
        {
            bool gasit = false;
            LinkedList<Pereche>.Enumerator iterator = myList.GetEnumerator();
            while (iterator.MoveNext())
                if (iterator.Current.cheie.CompareTo(key) == 0)
                {
                    gasit = true;
                    break;
                }
            if (gasit == true)
            {
                LinkedListNode<Pereche> nod = myList.Find(iterator.Current);
                return nod.Value.valoare;
            }
            else
            {
                return default(V);
            }
        }
    }
}