using Lab4.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Lab4.Dictionar;

namespace Lab4.Repository
{
    class RepositoryInBinaryFile<T> : Repository<T> where T : IDObject
    {
        private string fileName;

        public RepositoryInBinaryFile(String filename)
            : base()
        {
            this.fileName = filename;
            deserializeObject();
        }

        public void serializeObject()
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, myDictionary);
            stream.Close();
        }
        public void deserializeObject()
        {
            FileStream inStr = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            myDictionary = (Dictionar<int, T>)bf.Deserialize(inStr);
            inStr.Close();
        }

    }
}
