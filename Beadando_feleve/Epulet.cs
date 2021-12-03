using System.IO;

namespace Beadando_feleve
{
    class Epulet
    {
        public Felvono Lift  { get; private set; }
        public Emelet[] Emeletek { get; private set; }

        public Epulet(string fileNev)
        {
            string[] adatok = File.ReadAllLines(fileNev);
            Emeletek = new Emelet[int.Parse(adatok[0].Split(" ")[0])];
            Lift = new Felvono(int.Parse(adatok[0].Split(" ")[1]));
            for (int i = 1; i < adatok.Length; i++)
            {
                string[] sorString = adatok[i].Split(" ");
                int[] sorInt = new int[sorString.Length];
                for (int j = 0; j < sorInt.Length; j++)
                {
                    sorInt[j] = int.Parse(sorString[j]);
                }
                Emeletek[i - 1] = new Emelet(sorInt, i - 1);
                for (int j = 0; j < Emeletek[i-1].Emberek.Length; j++)
                {
                    Emeletek[i - 1].Emberek[j] = new Ember(i - 1, int.Parse(adatok[i].Split(" ")[j]));
                }
            }
        }
    }
}
