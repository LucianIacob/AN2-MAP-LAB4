using Lab4.Dictionar;
using Lab4.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.Repository;

namespace Lab4.Consola
{
    public class Consola
    {
        private Repository<Student> myRepo;

        public void run()
        {
            while (true)
            {
                System.Console.WriteLine("1. In memory");
                System.Console.WriteLine("2. In text file");
                System.Console.WriteLine("3. In binary file.");
                System.Console.Write("----Daţi opţiunea: ");
                string x = System.Console.ReadLine();
                try
                {
                    int cmd = Convert.ToInt32(x);
                    if (cmd == 1)
                    {
                        myRepo = new Repository<Student>();
                        myRepo.add(new Student(11474, "Guranda Bogdan", 9.6));
                        myRepo.add(new Student(11574, "Tiperciuc Corvin", 9.5));
                        myRepo.add(new Student(11434, "Galea Ronaldo", 7.4));
                        myRepo.add(new Student(17474, "Iacob Lucian", 7.3));
                        myRepo.add(new Student(14742, "Trif George", 9.99));
                        break;
                    }
                    else if (cmd == 2)
                    {
                        myRepo = new RepositoryInFile<Student>("C:\\Users\\Lucian\\SkyDrive\\Documents\\Visual Studio 2013\\ANUL II\\MAP\\Lab4\\data.txt");
                        break;
                    }
                    else if (cmd == 3)
                    {
                        myRepo = new RepositoryInBinaryFile<Student>("C:\\Users\\Lucian\\SkyDrive\\Documents\\Visual Studio 2013\\ANUL II\\MAP\\Lab4\\data.bin");
                        break;
                    }
                }
                catch (Exception) { System.Console.WriteLine(" @ Invalid command!"); }
            }

            while (true)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("---MENIU PRINCIPAL---");
                System.Console.WriteLine("1. Adaugă student.");
                System.Console.WriteLine("2. Caută student.");
                System.Console.WriteLine("3. Editează student.");
                System.Console.WriteLine("4. Elimină student.");
                System.Console.WriteLine("5. Afişează studenţii.");
                System.Console.WriteLine("0. Ieşire.");
                System.Console.Write("----Daţi opţiunea: ");

                string x = System.Console.ReadLine();
                try
                {
                    int cmd = Convert.ToInt32(x);
                    if (cmd == 0)
                    {
                        if ((myRepo as RepositoryInFile<Student>) != null)
                            ((RepositoryInFile<Student>)myRepo).saveToFile();
                        if ((myRepo as RepositoryInBinaryFile<Student>) != null)
                            ((RepositoryInBinaryFile<Student>)myRepo).serializeObject();
                        break;
                    }
                    else if (cmd == 1)
                    {
                        int nrmatricol = 0;
                        double media = 0;
                        System.Console.Write("Dati numarul matricol: ");
                        try
                        {
                            string nrm = System.Console.ReadLine();
                            nrmatricol = Convert.ToInt32(nrm);
                            if (myRepo.find(nrmatricol) != null)
                                System.Console.WriteLine(" @ Studentul exista deja!");
                            else
                            {
                                System.Console.Write("Dati numele studentului: ");
                                string nume = System.Console.ReadLine();

                                System.Console.Write("Dati media: ");
                                media = Convert.ToDouble(System.Console.ReadLine());

                                Student s = new Student(nrmatricol, nume, media);
                                System.Console.WriteLine(myRepo.add(s));
                            }
                        }
                        catch (Exception) { System.Console.WriteLine(" @ Invalid input!"); }
                    }

                    else if (cmd == 2)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = myRepo.find(nrmatricol);
                            if (o != null) System.Console.WriteLine(o.ToString());
                            else
                                System.Console.WriteLine(" @ Studentul nu exista!");
                        }
                        catch (Exception) { System.Console.WriteLine(" @ Invalid input!"); }
                    }

                    else if (cmd == 3)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol al studentului: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = (Student)myRepo.find(nrmatricol);
                            if (o == null)
                                System.Console.WriteLine(" @ Studentul nu exista!");
                            else
                            {
                                String nume = o.Nume;
                                System.Console.Write("Dati noua medie pentru acest student: ");
                                double media = Convert.ToDouble(System.Console.ReadLine());
                                System.Console.WriteLine(myRepo.update(new Student(nrmatricol, nume, media)));
                            }
                        }
                        catch (Exception) { System.Console.WriteLine(" @ Invalid input!"); }
                    }

                    else if (cmd == 4)
                    {
                        int nrmatricol = 0;
                        System.Console.Write("Dati numarul matricol al studentului: ");
                        try
                        {
                            nrmatricol = Convert.ToInt32(System.Console.ReadLine());
                            Student o = myRepo.find(nrmatricol);
                            if (o != default(Student)) System.Console.WriteLine(myRepo.remove(nrmatricol));
                            else
                                System.Console.WriteLine(" @ Ati introdus un numar matricol neexistent!");
                        }
                        catch (Exception) { System.Console.WriteLine(" @ Invalid input!"); }
                    }

                    else if (cmd == 5)
                    {
                        System.Console.WriteLine("---------");

                        foreach (Student s in myRepo.getList())
                        {
                            Console.WriteLine(s.ToString());
                        }

                        System.Console.WriteLine("---------");
                    }
                }
                catch (Exception) { System.Console.WriteLine(" @ Invalid command!"); }
            }
        }
    }
}
