using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Domain;
using Lab4.Repository;
using System.IO;

namespace Lab4.Repository
{
    class RepositoryInFile<T> : Repository<T> where T : IDObject
    {
        private string fileName;

        public RepositoryInFile(string FileName) : base()
        {
            this.fileName = FileName;
            readFromFile();
        }

        public void readFromFile()
        {
            TextReader tr = new StreamReader(fileName);
            string s;
            while ((s = tr.ReadLine()) != null) 
            {
                String[] lines = s.Split(';');
                Student stud = new Student(Int32.Parse(lines[0]), lines[1], Double.Parse(lines[2]));
                base.add((T)(object) stud);
            }
            tr.Close();
        }

        public void saveToFile()
        {
            TextWriter tw = new StreamWriter(fileName);
            foreach (T s in base.getList())
            {
                tw.WriteLine(s.ToString());
            }
            tw.Close();
        }
    }
}