

namespace Universitet_System
{
    public class Bok
    {
        public string ISBN { get; set; }
        public string Tittel { get; set; }
        public string Forfatter { get; set; }
        public int Utgivelsesår { get; set; }
        public int Eksemplarer { get; private set; }

        public Bok(string isbn, string tittel, string forfatter, int utgivelsesår, int eksemplarer)
        {
            ISBN = isbn;
            Tittel = tittel;
            Forfatter = forfatter;
            Utgivelsesår = utgivelsesår;
            Eksemplarer = eksemplarer;
        }

        public void LånUt()
        {
            if (Eksemplarer > 0)
            {
                Eksemplarer--;
                Console.WriteLine("Bok lånt ut!");
            }
            else
            {
                Console.WriteLine("Ingen tilgjengelige eksemplarer.");
            }
        }

        public void LeverTilbake()
        {
            Eksemplarer++;
        }

        public override string ToString()
        {
            string status = Eksemplarer > 0 ? "Tilgjengelig" : "Utlånt";
            return $"Bok: {Tittel} av {Forfatter} (ISBN: {ISBN}) - eksemplarer: {Eksemplarer}";
        }
    }
}