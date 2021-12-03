namespace Beadando_feleve
{
    enum FelvonoIrany { Fel, Le }
    class Felvono
    {
        public int AktualisEmelet { get; private set; }
        public int LiftKapacitas { get; }
        public int MenetekSzama { get; private set; }
        public FelvonoIrany Irany { get; private set; }
        public Ember[] Utasok { get; private set; }

        public Felvono(int kapacitas)
        {
            AktualisEmelet = 0;
            MenetekSzama = 0;
            LiftKapacitas = kapacitas;
            Irany = FelvonoIrany.Fel;
            Utasok = new Ember[0];
        }

        public void Halad(Epulet epulet)
        {
            Kiszall();
            if (epulet.Emeletek[AktualisEmelet].Emberek.Length != 0)
                for (int i = 0; i < epulet.Emeletek[AktualisEmelet].Emberek.Length; i++)
                    if (BeszallE(epulet.Emeletek[AktualisEmelet].Emberek[i]))
                        Beszall(epulet.Emeletek[AktualisEmelet].Emberek[i], epulet.Emeletek[AktualisEmelet]);
            AktualisEmelet = Irany == FelvonoIrany.Fel ? AktualisEmelet + 1 : AktualisEmelet - 1;
            if (AktualisEmelet == epulet.Emeletek.Length-1)
            {
                Irany = FelvonoIrany.Le;
                MenetekSzama++;
            }
            if (AktualisEmelet == 0)
            {
                Irany = FelvonoIrany.Fel;
                MenetekSzama++;
            }
        }

        private void Kiszall()
        {
            for (int i = 0; i < Utasok.Length; i++)
            {
                if (Utasok[i].Hova == AktualisEmelet)
                    UtasTorlese(Utasok[i]);
            }
        }
        private bool BeszallE(Ember utas)
        {
            if (utas.Honnan < utas.Hova && Irany == FelvonoIrany.Fel ||
                utas.Hova < utas.Honnan && Irany == FelvonoIrany.Le)
                return true;
            return false;
        }
        private void Beszall(Ember beszallo, Emelet emelet)
        {
            if (Utasok.Length < LiftKapacitas)
            {
                Ember[] tmp = new Ember[Utasok.Length + 1];
                for (int i = 0; i < Utasok.Length; i++)
                    tmp[i] = Utasok[i];
                tmp[Utasok.Length] = beszallo;
                emelet.BeszalloUtas(beszallo);
                Utasok = tmp;
            }

        }
        private void UtasTorlese(Ember utas)
        {
            Ember[] tmp = new Ember[Utasok.Length - 1];
            int seged = 0;
            for (int i = 0; i < Utasok.Length; i++)
                if (Utasok[i] != utas)
                    tmp[seged++] = utas;
            Utasok = tmp;
        }
        
    }
}
