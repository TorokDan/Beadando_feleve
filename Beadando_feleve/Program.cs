using System;

namespace Beadando_feleve
{
    class Program
    {
        static void Main(string[] args)
        {
            Epulet epulet = new Epulet("input.txt");
            for (int i = 0; i < epulet.Emeletek.Length; i++)
            {
                for (int j = 0; j < epulet.Emeletek[i].Emberek.Length; j++)
                {
                    Console.Write(i +", " + epulet.Emeletek[i].Emberek[j].Hova + ", ");
                    Console.Write(epulet.Emeletek[i].Emberek[j].Honnan + "\n");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < epulet.Lift.Utasok.Length; i++)
            {
                Console.WriteLine(epulet.Lift.Utasok[i]); 
            }
            Console.WriteLine(epulet.Emeletek[0]);
            epulet.Lift.KiszallBeszall(epulet.Emeletek[0], epulet);
            for (int i = 0; i < epulet.Lift.Utasok.Length; i++)
            {
                Console.Write(epulet.Lift.Utasok[i].Honnan + ", ");
                Console.Write(epulet.Lift.Utasok[i].Hova + "\n");
            }   
            ;
        }
    }
}

