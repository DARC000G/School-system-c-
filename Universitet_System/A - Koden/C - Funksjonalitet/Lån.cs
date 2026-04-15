using System;

namespace Universitet_System
{
    public class Lån
    {
        public Bruker Bruker { get; }
        public Bok Bok { get; }
        public DateTime LåntDato { get; }
        public DateTime? ReturnertDato { get; set; }

        public Lån(Bruker bruker, Bok bok, DateTime låntDato)
        {
            Bruker = bruker;
            Bok = bok;
            LåntDato = låntDato;
            ReturnertDato = null;
        }
    

        public override string ToString()
        {
            string status = ReturnertDato == null
                ? "Aktiv"
                : $"Returnert {ReturnertDato:yyyy-MM-dd}";

            return $"{Bok.Tittel} ({Bok.ISBN}) – {status}";
        }
    }
}
