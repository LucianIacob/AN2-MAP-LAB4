using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.IDictionar
{
    interface IDictionar<K, V> where K: IComparable<K>
    {
        Boolean add(K key, V valoare);
        Boolean update(K key, V val);
        Boolean remove(K id);
        V find(K key);
    }
}
