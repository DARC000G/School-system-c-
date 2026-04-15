using System;
using System.Collections.Generic;
using System.Linq;

namespace Universitet_System
{
    public class CourseService
    {
        private readonly List<Kurs> _kursListe;

        public CourseService(List<Kurs> kursListe)
        {
            _kursListe = kursListe;
        }

        public void VisAlleKurs()
        {
            Console.WriteLine("\n=== ALLE KURS ===");
            if (!_kursListe.Any())
            {
                Console.WriteLine("Ingen kurs registrert.");
                return;
            }

            foreach (var k in _kursListe)
            {
                Console.WriteLine($"{k.Kode} - {k.Navn} (Max {k.MaksStudenter})");
            }
        }

        public void SøkKurs()
        {
            Console.Write("\nSøk på kurskode eller navn: ");
            string søk = Console.ReadLine();

            var treff = _kursListe
                .Where(k =>
                    k.Kode.Contains(søk, StringComparison.OrdinalIgnoreCase) ||
                    k.Navn.Contains(søk, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!treff.Any())
            {
                Console.WriteLine("Ingen kurs funnet.");
                return;
            }

            Console.WriteLine("\nTreff:");
            foreach (var k in treff)
            {
                Console.WriteLine($"{k.Kode} - {k.Navn} ({k.Studenter.Count}/{k.MaksStudenter})");
            }
        }

        public void MeldPåKurs(Student s)
        {
            Console.Write("\nSkriv kurskode: ");
            string kode = Console.ReadLine();

            var kurs = _kursListe.FirstOrDefault(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            if (kurs.Studenter.Contains(s))
            {
                Console.WriteLine("Du er allerede påmeldt dette kurset.");
                return;
            }

            if (kurs.Studenter.Count >= kurs.MaksStudenter)
            {
                Console.WriteLine("Kurset er fullt.");
                return;
            }

            kurs.Studenter.Add(s);
            s.KursListe.Add(kurs);

            Console.WriteLine($"Meldt på {kurs.Navn}");
        }

        public void MeldAvKurs(Student s)
        {
            Console.Write("\nSkriv kurskode: ");
            string kode = Console.ReadLine();

            var kurs = _kursListe.FirstOrDefault(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            if (!kurs.Studenter.Contains(s))
            {
                Console.WriteLine("Du er ikke påmeldt dette kurset.");
                return;
            }

            kurs.Studenter.Remove(s);
            s.KursListe.Remove(kurs);

            Console.WriteLine($"Meldt av {kurs.Navn}");
        }

        public void VisStudentKurs(Student s)
        {
            Console.WriteLine("\n=== Mine kurs ===");
            if (!s.KursListe.Any())
            {
                Console.WriteLine("Ingen kurs.");
                return;
            }

            foreach (var k in s.KursListe)
            {
                Console.WriteLine($"{k.Kode} - {k.Navn}");
            }
        }

        public void VisStudentKarakterer(Student s)
        {
            Console.WriteLine("\n=== Mine karakterer ===");
            var kursMedKarakter = _kursListe
                .Where(k => k.Karakterer.ContainsKey(s))
                .ToList();

            if (!kursMedKarakter.Any())
            {
                Console.WriteLine("Ingen karakterer registrert.");
                return;
            }

            foreach (var k in kursMedKarakter)
            {
                Console.WriteLine($"{k.Kode} - {k.Navn}: {k.Karakterer[s]}");
            }
        }

        public void OpprettKurs(Faglaerer f)
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine();

            if (_kursListe.Any(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Kurskode finnes allerede.");
                return;
            }

            Console.Write("Navn: ");
            string navn = Console.ReadLine();

            if (_kursListe.Any(k => k.Navn.Equals(navn, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Et kurs med dette navnet finnes allerede.");
                return;
            }

            int maks;
            while (true)
            {
                Console.Write("Maks studenter: ");
                if (int.TryParse(Console.ReadLine(), out maks) && maks > 0) break;
                Console.WriteLine("Ugyldig tall.");
            }

            var kurs = new Kurs(kode, navn, f, maks);
            _kursListe.Add(kurs);

            Console.WriteLine("Kurs opprettet.");
        }

        public void LeggTilPensum(Faglaerer f)
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine();

            var kurs = _kursListe.FirstOrDefault(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.Write("Pensumtekst: ");
            string pensum = Console.ReadLine();

            kurs.Pensum = pensum;
            Console.WriteLine("Pensum oppdatert.");
        }

        public void SettKarakter(Faglaerer f)
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine();

            var kurs = _kursListe.FirstOrDefault(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            if (!kurs.Studenter.Any())
            {
                Console.WriteLine("Ingen studenter påmeldt.");
                return;
            }

            Console.WriteLine("\nStudenter på kurset:");
            for (int i = 0; i < kurs.Studenter.Count; i++)
            {
                var s = kurs.Studenter[i];
                string eksisterende = kurs.Karakterer.ContainsKey(s) ? kurs.Karakterer[s] : "-";
                Console.WriteLine($"{i + 1}) {s.StudentID} - {s.FulltNavn} (Karakter: {eksisterende})");
            }

            Console.Write("Velg student (nummer): ");
            if (!int.TryParse(Console.ReadLine(), out int valg) || valg < 1 || valg > kurs.Studenter.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            var valgtStudent = kurs.Studenter[valg - 1];

            Console.Write("Ny karakter (f.eks. A-F, eller tom for å fjerne): ");
            string karakter = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(karakter))
            {
                if (kurs.Karakterer.ContainsKey(valgtStudent))
                {
                    kurs.Karakterer.Remove(valgtStudent);
                    Console.WriteLine("Karakter fjernet.");
                }
                else
                {
                    Console.WriteLine("Ingen karakter å fjerne.");
                }
            }
            else
            {
                kurs.Karakterer[valgtStudent] = karakter.ToUpper();
                Console.WriteLine("Karakter satt/oppdatert.");
            }
        }

        public void VisAlleStudenter(List<Bruker> brukere)
        {
            Console.WriteLine("\n=== Alle studenter ===");

            var studenter = brukere.OfType<Student>().ToList();

            if (!studenter.Any())
            {
                Console.WriteLine("Ingen studenter registrert.");
                return;
            }

            foreach (var s in studenter)
            {
                Console.WriteLine($"{s.StudentID} | {s.FulltNavn} | {s.Epost}");

                if (s is UtvekslingStudent u)
                {
                    Console.WriteLine($"   Utveksling: {u.HjemUniversitet}, {u.Land} ({u.PeriodeFra:yyyy-MM-dd} → {u.PeriodeTil:yyyy-MM-dd})");
                }
            }
        }

        public void VisStudenterIKurs(Faglaerer f)
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine();

            var kurs = _kursListe.FirstOrDefault(k => k.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.WriteLine($"\nStudenter i {kurs.Kode} - {kurs.Navn}:");

            if (!kurs.Studenter.Any())
            {
                Console.WriteLine("Ingen studenter påmeldt.");
                return;
            }

            foreach (var s in kurs.Studenter)
            {
                if (s is UtvekslingStudent u)
                {
                    Console.WriteLine($"{s.StudentID} | {s.FulltNavn} | {s.Epost}");
                    Console.WriteLine($"   Utveksling: {u.HjemUniversitet}, {u.Land} ({u.PeriodeFra:yyyy-MM-dd} → {u.PeriodeTil:yyyy-MM-dd})");
                }
                else
                {
                    Console.WriteLine($"{s.StudentID} | {s.FulltNavn} | {s.Epost}");
                }
            }
        }
    }
}
