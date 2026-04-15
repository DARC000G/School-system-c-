using System;
using System.Linq;

namespace Universitet_System
{
    public class LibraryService
    {
        private readonly Bibliotek _bibliotek;

        public LibraryService(Bibliotek bibliotek)
        {
            _bibliotek = bibliotek;
        }

        public void SøkBok()
        {
            Console.Write("\nSøk etter tittel eller ISBN: ");
            string søk = Console.ReadLine();

            var treff = _bibliotek.BokListe
                .Where(b =>
                    b.Tittel.Contains(søk, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Equals(søk, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!treff.Any())
            {
                Console.WriteLine("Ingen bøker funnet.");
                return;
            }

            Console.WriteLine("\nTreff:");
            foreach (var bok in treff)
            {
                Console.WriteLine($"{bok.ISBN} - {bok.Tittel} ({bok.Forfatter}) [{bok.AntallEksemplarer} eks]");
            }
        }

        public void VisAlleBøker()
        {
            Console.WriteLine("\n=== ALLE BØKER ===");
            if (!_bibliotek.BokListe.Any())
            {
                Console.WriteLine("Ingen bøker registrert.");
                return;
            }

            foreach (var bok in _bibliotek.BokListe)
            {
                Console.WriteLine($"{bok.ISBN} - {bok.Tittel} ({bok.Forfatter}) [{bok.AntallEksemplarer} eks]");
            }
        }

        public void LånBok(Bruker bruker)
        {
            Console.Write("\nISBN eller tittel: ");
            string søk = Console.ReadLine();

            var bok = _bibliotek.BokListe.FirstOrDefault(b =>
                b.ISBN.Equals(søk, StringComparison.OrdinalIgnoreCase) ||
                b.Tittel.Equals(søk, StringComparison.OrdinalIgnoreCase));

            if (bok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            bool harAlleredeLån = _bibliotek.LånListe.Any(l =>
                l.Bruker == bruker &&
                l.Bok == bok &&
                l.ReturnertDato == null);

            if (harAlleredeLån)
            {
                Console.WriteLine("Du har allerede et aktivt lån på denne boka.");
                return;
            }

            if (bok.AntallEksemplarer <= 0)
            {
                Console.WriteLine("Ingen eksemplarer ledig.");
                return;
            }

            bok.AntallEksemplarer--;
            _bibliotek.LeggTilLån(new Lån(bruker, bok, DateTime.Now));

            Console.WriteLine($"Lånte: {bok.Tittel}");
        }

        public void ReturnerBok(Bruker bruker)
        {
            Console.WriteLine("\n=== Mine aktive lån ===");
            var lån = _bibliotek.LånListe
                .Where(l => l.Bruker == bruker && l.ReturnertDato == null)
                .ToList();

            if (!lån.Any())
            {
                Console.WriteLine("Ingen aktive lån.");
                return;
            }

            for (int i = 0; i < lån.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {lån[i].Bok.Tittel} ({lån[i].Bok.ISBN}) - Lånt: {lån[i].LåntDato:yyyy-MM-dd}");
            }

            Console.Write("Velg bok å returnere (nummer): ");
            if (!int.TryParse(Console.ReadLine(), out int valg) || valg < 1 || valg > lån.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            var valgtLån = lån[valg - 1];
            valgtLån.ReturnertDato = DateTime.Now;
            valgtLån.Bok.AntallEksemplarer++;

            Console.WriteLine($"Returnerte: {valgtLån.Bok.Tittel}");
        }

        public void VisMineLån(Bruker bruker)
        {
            Console.WriteLine("\n=== Mine lån ===");
            var lån = _bibliotek.LånListe
                .Where(l => l.Bruker == bruker)
                .ToList();

            if (!lån.Any())
            {
                Console.WriteLine("Ingen lån.");
                return;
            }

            foreach (var l in lån)
            {
                string status = l.ReturnertDato == null ? "Aktiv" : $"Returnert {l.ReturnertDato:yyyy-MM-dd}";
                Console.WriteLine($"{l.Bok.Tittel} ({l.Bok.ISBN}) - Lånt {l.LåntDato:yyyy-MM-dd} - {status}");
            }
        }

        public void RegistrerNyBok()
        {
            Console.WriteLine("\n=== Registrer ny bok ===");

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            if (_bibliotek.BokListe.Any(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("En bok med denne ISBN finnes allerede.");
                return;
            }

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine();

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine();

            int år;
            while (true)
            {
                Console.Write("År: ");
                if (int.TryParse(Console.ReadLine(), out år)) break;
                Console.WriteLine("Ugyldig år.");
            }

            int antall;
            while (true)
            {
                Console.Write("Antall eksemplarer: ");
                if (int.TryParse(Console.ReadLine(), out antall) && antall >= 0) break;
                Console.WriteLine("Ugyldig antall.");
            }

            _bibliotek.LeggTilBok(new Bok(isbn, tittel, forfatter, år, antall));

            Console.WriteLine("Bok registrert!");
        }

        public void EndreBok()
        {
            Console.WriteLine("\n=== Endre bok ===");
            Console.Write("Søk etter bok (ISBN eller tittel): ");
            string søk = Console.ReadLine();

            var bok = _bibliotek.BokListe.FirstOrDefault(b =>
                b.ISBN.Equals(søk, StringComparison.OrdinalIgnoreCase) ||
                b.Tittel.Equals(søk, StringComparison.OrdinalIgnoreCase));

            if (bok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            Console.WriteLine($"\nEndrer: {bok.Tittel} ({bok.ISBN})");

            Console.Write("Ny tittel (enter for å beholde): ");
            string nyTittel = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyTittel))
                bok.Tittel = nyTittel;

            Console.Write("Ny forfatter (enter for å beholde): ");
            string nyForfatter = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyForfatter))
                bok.Forfatter = nyForfatter;

            Console.Write("Nytt år (enter for å beholde): ");
            string årInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(årInput) && int.TryParse(årInput, out int nyttÅr))
                bok.År = nyttÅr;

            Console.Write("Nytt antall eksemplarer (enter for å beholde): ");
            string antallInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(antallInput) && int.TryParse(antallInput, out int nyttAntall))
                bok.AntallEksemplarer = nyttAntall;

            Console.WriteLine("Bok oppdatert!");
        }

        public void VisAlleAktiveLån()
        {
            Console.WriteLine("\n=== Aktive lån ===");
            var aktive = _bibliotek.LånListe
                .Where(l => l.ReturnertDato == null)
                .ToList();

            if (!aktive.Any())
            {
                Console.WriteLine("Ingen aktive lån.");
                return;
            }

            foreach (var l in aktive)
            {
                Console.WriteLine($"{l.Bruker.Epost} -> {l.Bok.Tittel} ({l.Bok.ISBN}) - Lånt {l.LåntDato:yyyy-MM-dd}");
            }
        }

        public void VisLånehistorikk()
        {
            Console.WriteLine("\n=== Lånehistorikk ===");
            if (!_bibliotek.LånListe.Any())
            {
                Console.WriteLine("Ingen lån registrert.");
                return;
            }

            foreach (var l in _bibliotek.LånListe)
            {
                string status = l.ReturnertDato == null ? "Aktiv" : $"Returnert {l.ReturnertDato:yyyy-MM-dd}";
                Console.WriteLine($"{l.Bruker.Epost} -> {l.Bok.Tittel} ({l.Bok.ISBN}) - Lånt {l.LåntDato:yyyy-MM-dd} - {status}");
            }
        }
    }
}
