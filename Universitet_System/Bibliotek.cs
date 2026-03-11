

namespace Universitet_System
{
    public class Bibliotek
    {
        // liste over alle bøker o bibliotek
        public List<Bok> Bøker { get; } = new List<Bok>();

        // legge til en bok i biblioteket
        public void LeggTilBok(Bok bok)
        {
            Bøker.Add(bok);
        }

        // vise alle bøker i biblioteket
        public void VisAlleBøker()
        {
            Console.WriteLine("Bøker i biblioteket:");
            foreach (var bok in Bøker)
            {
                Console.WriteLine(bok);
            }
        }

        public Bok? FinnBok(string tittel)
        {
            return Bøker.Find(b => b.Tittel.Equals(tittel, StringComparison.OrdinalIgnoreCase));
        }
    }
}