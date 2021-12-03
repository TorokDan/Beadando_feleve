using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_feleve
{
    class Emelet
    {
        public Ember[] Emberek { get; set; }
        public int Hanyadik { get; private set; }

        public Emelet(int[] hovak, int hanyadik)
        {
            Hanyadik = hanyadik;
            Emberek = new Ember[hovak.Length];
            for (int i = 0; i < hovak.Length; i++)
                Emberek[i] = new Ember(hanyadik, hovak[i]);
            Emberek = Rendezes(Emberek);
        }

        Ember[] Rendezes(Ember[] emberek)
        {
            for (int i = 0; i < emberek.Length; i++)
            {
                int j = i - 1;
                Ember seged = emberek[i];
                while (j >= 0 && emberek[i].Hova < seged.Hova)
                {
                    emberek[j + 1] = emberek[j];
                    j--;
                }
                emberek[j + 1] = seged;
            }
            return emberek;
        }
    }
}
