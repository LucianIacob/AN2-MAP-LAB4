using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Domain
{
    [Serializable()]
    public class Student : IDObject
    {

        private int matricol;
        private string nume;
        private double media;

        public string Nume
        {
            get
            {
                return this.nume;
            }
            set
            {
                this.nume = value;
            }
        }
        public int Matricol
        {
            get
            {
                return this.matricol;
            }
            set
            {
                this.matricol = value;
            }
        }
        public double Medie
        {
            get
            {
                return media;
            }
            set
            {
                this.media = value;
            }
        }

        Student()
        {
            matricol = 1;
            nume = "";
            media = 0;
        }

        
        public Student(int nrmatricol, string nume, double media)
        {
            // TODO: Complete member initialization
            this.matricol = nrmatricol;
            this.nume = nume;
            this.media = media;
        }
        public override string ToString()
        {
            return matricol + ";" + nume + ";" + media;
        }

        public int getID()
        {
            return this.matricol;
        }
    }
}
