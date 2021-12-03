namespace Beadando_feleve
{
    class Ember
    {
        public int Honnan { get; }
        public int Hova { get; }
        public int Tavolsag { get; }

        public Ember() :this(0,0) { }
        public Ember(int honnan, int hova)
        {
            this.Honnan = honnan;
            this.Hova = hova;
            Tavolsag = Hova - Honnan;
        }
    }
}
