namespace Beadando_feleve
{
    enum FelvonoIrany { Fel, Le }
    class Felvono
    {
        public int AktualisEmelet { get; }
        public int LiftKapacitas { get; }
        public int LepesekSzama { get; private set; }
        public FelvonoIrany Irany { get; private set; }
        public Ember[] Utasok { get; private set; }

        public Felvono(int kapacitas)
        {
            AktualisEmelet = 0;
            LepesekSzama = 0;
            LiftKapacitas = kapacitas;
            Irany = FelvonoIrany.Fel;
            Utasok = new Ember[0];
        }

        public void KiszallBeszall(Emelet emelet, Epulet epulet)
        {
            Ember[] tmp = new Ember[0];
            if (Irany == FelvonoIrany.Fel && LepesekSzama != 0)
                tmp = Kirak(Utasok, emelet, epulet);
            if (Irany == FelvonoIrany.Fel )
                tmp = FelveszFel(Utasok, emelet);
            if (Irany == FelvonoIrany.Le)
                tmp = FelveszLe(Utasok, emelet);
            Utasok = tmp;
            LepesekSzama++;
        }
        public Ember[] Kirak(Ember[] emberek, Emelet emelet, Epulet epulet)
        {
            Ember[] tmp = new Ember[0];
            for (int i = 0; i < emberek.Length; i++)
                if (emberek[i].Hova != emelet.Hanyadik)
                {
                    Ember[] tmpSeged = new Ember[tmp.Length + 1];
                    for (int j = 0; j < tmp.Length; j++)
                        tmpSeged[j] = tmp[j];
                    tmpSeged[tmpSeged.Length] = emberek[i];
                    tmp = tmpSeged;
                }
            if (emelet.Hanyadik == epulet.Emeletek.Length - 1 )
                Irany = FelvonoIrany.Le;
            if (emelet.Hanyadik == 0 && Irany == FelvonoIrany.Le)
                Irany = FelvonoIrany.Fel;
            return tmp;
        }
        public Ember[] FelveszFel(Ember[] emberekBent, Emelet emelet)
        {
            Ember[] tmpSeged = new Ember[LiftKapacitas];
            for (int i = 0; i < emberekBent.Length; i++)
                tmpSeged[i] = emberekBent[i];
            int segedSzamlalo = 0;
            for (int i = emberekBent.Length; i < tmpSeged.Length; i++)
            {
                tmpSeged[i] = emelet.Emberek[segedSzamlalo++];
            }

            return emberekBent;
        }
        public Ember[] FelveszLe(Ember[] emberekBent, Emelet emelet)
        {
            Ember[] tmp = emelet.Emberek;
            for (int i = 0; i < emelet.Emberek.Length && emberekBent.Length < LiftKapacitas; i++)
            {
                if (emelet.Hanyadik < emelet.Emberek[i].Hova)
                {
                    Ember[] tmpSeged = new Ember[emberekBent.Length + 1];
                    for (int j = 0; j > tmpSeged.Length; j++)
                        tmpSeged[j] = emberekBent[j];
                    tmpSeged[tmpSeged.Length] = emelet.Emberek[i];
                    emberekBent = tmpSeged;
                    tmpSeged = new Ember[tmp.Length - 1];
                    int tmpSegedSzamlalo = 0;
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        if (tmp[j] != emelet.Emberek[i])
                            tmpSeged[tmpSegedSzamlalo++] = tmp[j];
                        tmp = tmpSeged;
                    }
                }
            }
            emelet.Emberek = tmp;
            return emberekBent;
        }
    }
}
