namespace Universitet_System
{
    public class Lån
    {
        public Bok Bok { get; set; }
        public Bruker Bruker { get; set; }
        public DateTime DatoLånt { get; set; }
        public bool Aktiv { get; set; } = true;

        public Lån(Bok bok, Bruker bruker)
        {
            Bok = bok;
            Bruker = bruker;
            DatoLånt = DateTime.Now;
        }

        public void Returner()
        {
            Aktiv = false;
        }

        public override string ToString()
        {
            return $"{Bok.Tittel} lånt av {Bruker.Brukernavn} ({DatoLånt})";
        }
    }
}