using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Students = File.ReadAllLines("Estudiantes.txt").ToList();
            List<string> Groups = File.ReadAllLines("Grupos.txt").ToList();
            List<string> Subjects = File.ReadAllLines("Temas.txt").ToList();

            PrintList(Students, Groups, Subjects);
            Console.WriteLine();

            int input = 0;
            while (input != -1)
            {
                Console.WriteLine("Presione Enter para Agruparlos o -1 para Salir");
                string n = Console.ReadLine();

                if (n.Equals(""))
                    input = 1;
                else 
                    input = Convert.ToInt32(n);

                GroupAll();
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("Se ha salido sastifactoriamente...");
            Console.ReadKey();
          
        }


        public static void PrintList(List<string> studentList, List<string> groupList, List<string> subjectList)
        {
            Console.WriteLine("###Lista de Estudiantes###");
            int count = 1;
            foreach (var item in studentList)
            {
                Console.WriteLine($"   {count}- {item}");
                count++;
            }           

            Console.WriteLine();
            Console.WriteLine("###Lista de Grupos###");
            count = 1;
            foreach (var item in groupList)
            {
                Console.WriteLine($"   {count}- {item}");
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("###Lista de Temas###");
            count = 1;
            foreach (var item in subjectList)
            {
                Console.WriteLine($"  - {item}");
                count++;
            }
        }
        public static void GroupAll()
        {
            List<string> StudentsCopy = File.ReadAllLines("Estudiantes.txt").ToList();
            List<string> GroupsCopy = File.ReadAllLines("Grupos.txt").ToList();
            List<string> SubjectsCopy = File.ReadAllLines("Temas.txt").ToList();


            Dictionary<string, string> GroupStudents = Grouper(StudentsCopy, GroupsCopy);
            Dictionary<string, string> GroupSubjects = Grouper(SubjectsCopy, GroupsCopy);


            Console.Clear();
            foreach (var group in GroupsCopy)
            {
                Console.WriteLine();
                List<string> printStudents = new List<string>();
                List<string> printSubjects = new List<string>();

                int count = 1;
                foreach (var item in GroupStudents)
                {
                    if (item.Value.Equals(group))
                    {
                        printStudents.Add(item.Key);
                    }
                }
                foreach (var item in GroupSubjects)
                {
                    if (item.Value.Equals(group))
                    {
                        printSubjects.Add(item.Key);
                    }
                }

                Console.WriteLine($"#{group}# Cantidad: {printStudents.Count}" );
                foreach (var item in printStudents)
                {
                    Console.WriteLine($"{count}) {item}");
                    count++;
                }
                Console.WriteLine("-Temas: " + printSubjects.Count);
                foreach (var item in printSubjects)
                {
                    Console.Write(item);
                    Console.Write(" | ");
                }

                Console.WriteLine();
            }
        }
        public static Dictionary<string, string> Grouper(List<string> repartirList, List<string> gruposList)
        {
            Dictionary<string, string> groupedDictionary = new Dictionary<string, string>();
            int groupId = 0;
            Random random = new Random();

            while (repartirList.Count > 0)
            {
                if (groupId.Equals(gruposList.Count))
                    groupId = 0;

                
                foreach (var VARIABLE in gruposList)
                {
                    int studentId = 0;
                    if (repartirList.Count > 0)
                    {
                        studentId = random.Next(0, repartirList.Count);
                    }
                    else
                        break;

                    groupedDictionary.Add(repartirList[studentId], gruposList[groupId]);
                    groupId++;
                    repartirList.RemoveAt(studentId);
                }
            }

            return groupedDictionary;
        }     
    }
}
