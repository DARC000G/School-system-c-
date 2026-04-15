namespace Universitet_System
{
    public class Bok
    {
        public string ISBN { get; }
        public string Tittel { get; set; }
        public string Forfatter { get; set; }
        public int År { get; set; }
        public int AntallEksemplarer { get; set; }

        public Bok(string isbn, string tittel, string forfatter, int år, int antall)
        {
            ISBN = isbn;
            Tittel = tittel;
            Forfatter = forfatter;
            År = år;
            AntallEksemplarer = antall;
        }

        public override string ToString()
            => $"{ISBN} - {Tittel} ({Forfatter}, {År}) – Eksemplarer: {AntallEksemplarer}";
    }
}
