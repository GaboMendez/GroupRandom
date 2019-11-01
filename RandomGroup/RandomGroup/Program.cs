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
    }
}
