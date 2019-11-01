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
            string[] Students = File.ReadAllLines("Estudiantes.txt");
            string[] Groups = File.ReadAllLines("Grupos.txt");
            string[] Subjects = File.ReadAllLines("Temas.txt");

            Console.WriteLine();

        }



        public Dictionary<int,int> Grouper(List<string> repartirList, List<string> gruposList)
        {
            Dictionary<int,int> groupedDictionary = new Dictionary<int, int>();
            int groupId = 0;

            while (repartirList.Count > 0)
            {
                foreach (var VARIABLE in gruposList)
                {
                    Random random = new Random();
                    int studentId = 0;
                    if (repartirList.Count > 0)
                    {
                        studentId = random.Next(0, repartirList.Count);
                    }
                    groupedDictionary.Add(studentId, groupId);
                    groupId++;
                    repartirList.RemoveAt(studentId);
                }
            }

            return groupedDictionary;
        }

    }
}
