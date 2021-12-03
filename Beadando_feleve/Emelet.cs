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
            Ember[] tmp = new Ember[hovak.Length];
            for (int i = 0; i < hovak.Length; i++)
                tmp[i] = new Ember(hanyadik, hovak[i]);
            Rendezes(tmp);
        }

        private void Rendezes(Ember[] emberek)
        {
            for (int i = 0; i < emberek.Length; i++)
            {
                int j = i - 1;
                Ember seged = emberek[i];
                while (j >= 0 && emberek[j].Hova > seged.Hova)
                {
                    emberek[j + 1] = emberek[j];
                    j--;
                }
                emberek[j + 1] = seged;
            }
            Emberek = emberek;
        }

        public void BeszalloUtas(Ember ember)
        {
            if (Emberek.Length != 0)
            {
                Ember[] tmp = new Ember[Emberek.Length - 1];
                int seged = 0;
                for (int i = 0; i < Emberek.Length; i++)
                    if (Emberek[i] != ember)
                        tmp[seged++] = Emberek[i];
                Emberek = tmp;
            }
        }
    }
}
