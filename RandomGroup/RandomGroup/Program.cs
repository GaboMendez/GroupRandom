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

            List<string> StudentsCopy = File.ReadAllLines("Estudiantes.txt").ToList();
            List<string> GroupsCopy = File.ReadAllLines("Grupos.txt").ToList();
            List<string> SubjectsCopy = File.ReadAllLines("Temas.txt").ToList();

            Dictionary<string, string> ret = Grouper(StudentsCopy, GroupsCopy);

            foreach (var item in ret)
            {

                Console.WriteLine($"{item.Key} | {item.Value}");
                Console.WriteLine();
            }
            Console.WriteLine();

        }



        public static Dictionary<string, string> Grouper(List<string> repartirList, List<string> gruposList)
        {
            Dictionary<string, string> groupedDictionary = new Dictionary<string, string>();
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
                    groupedDictionary.Add(repartirList[studentId], gruposList[groupId]);
                    groupId++;
                    repartirList.RemoveAt(studentId);
                }
            }

            return groupedDictionary;
        }
    }
}
