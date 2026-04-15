using System.Collections.Generic;

namespace Universitet_System
{
    public class Bibliotek
    {
        public List<Bok> BokListe { get; } = new();
        public List<Lån> LånListe { get; } = new();

        public void LeggTilBok(Bok bok)
        {
            BokListe.Add(bok);
        }

        public void LeggTilLån(Lån lån)
        {
            LånListe.Add(lån);
        }
    }
}
