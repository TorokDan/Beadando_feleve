using System;
using System.IO;

namespace Beadando_feleve
{
    class Program
    {
        static void Main(string[] args)
        {
            Epulet epulet = new Epulet("input.txt");
            while (epulet.VanEMegBeszallo())
            {
                Console.WriteLine("asd");
                epulet.LiftElindul();
            }
            FilebaIras("output.txt", epulet.Lift.MenetekSzama);
        }
        static void FilebaIras(string fileName, int szam)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(szam);
            sw.Close();
        }
    }
}

