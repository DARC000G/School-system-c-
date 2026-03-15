namespace Universitet_System
{
    public class Bok
    {
        public string ISBN { get; set; }
        public string Tittel { get; set; }
        public string Forfatter { get; set; }
        public int År { get; set; }
        public int AntallEksemplarer { get; set; }

        public Bok(string isbn, string tittel, string forfatter, int år, int antallEksemplarer)
        {
            ISBN = isbn;
            Tittel = tittel;
            Forfatter = forfatter;
            År = år;
            AntallEksemplarer = antallEksemplarer;
        }

        public override string ToString()
        {
            return $"{Tittel} ({Forfatter}, {År}) – ISBN: {ISBN} – Eksemplarer: {AntallEksemplarer}";
        }
    }
}
