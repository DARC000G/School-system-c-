namespace Universitet_System
{
    public class Bibliotek
    {
        public List<Bok> BokListe { get; set; } = new List<Bok>();
        public List<Lån> LånListe { get; set; } = new List<Lån>();

        public void LeggTilBok(Bok bok)
        {
            BokListe.Add(bok);
        }

        public Bok? FinnBok(string tittel)
        {
            return BokListe.Find(b =>
                b.Tittel.Contains(tittel, StringComparison.OrdinalIgnoreCase));
        }

        public void VisAlleBøker()
        {
            foreach (var bok in BokListe)
                Console.WriteLine(bok);
        }
    }
}
