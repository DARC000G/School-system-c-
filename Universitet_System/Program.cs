using System;
using System.Collections.Generic;

namespace Universitet_System
{
    class Program
    {
        // Globale lister
        static List<Kurs> kursListe = new List<Kurs>();
        static Bibliotek bibliotek = new Bibliotek();

        static void Main(string[] args)
        {
            // Legg inn noen testdata
            bibliotek.LeggTilBok(new Bok("978-3-16-148410-0", "C# Programmering", "Forfatter A", 2020, 69));
            bibliotek.LeggTilBok(new Bok("978-1-23-456789-7", "Læring av maskiner", "Forfatter B", 2021, 24));
            bibliotek.LeggTilBok(new Bok("978-0-12-345678-9", "Databaser for utviklere", "Forfatter C", 2019, 100));

            while (true)
            {
                Console.WriteLine("\nVelkommen til Universitet System");
                Console.WriteLine("1. Opprett kurs");
                Console.WriteLine("2. Meld student til kurs");
                Console.WriteLine("3. Print kurs og deltagere");
                Console.WriteLine("4. Søk på kurs");
                Console.WriteLine("5. Søk på bok");
                Console.WriteLine("6. Lån bok");
                Console.WriteLine("7. Returner bok");
                Console.WriteLine("8. Registrer bok");
                Console.WriteLine("0. Avslutt");

                Console.Write("\nVelg et alternativ: ");
                string valg = Console.ReadLine() ?? string.Empty;

                switch (valg)
                {
                    case "1": OpprettKurs(); break;
                    case "2": MeldPå(); break;
                    case "3": PrintKursOgDeltagere(); break;
                    case "4": SøkPåKurs(); break;
                    case "5": SøkPåBok(); break;
                    case "6": LånBok(); break;
                    case "7": ReturnerBok(); break;
                    case "8": RegistrerBok(); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        // ===============================
        // MENYFUNKSJONER
        // ===============================

        static void OpprettKurs()
        {
            Console.Write("\nKursnavn: ");
            string kursnavn = Console.ReadLine() ?? string.Empty;

            Console.Write("Kurskode: ");
            string kurskode = Console.ReadLine() ?? string.Empty;

            Console.Write("Studiepoeng: ");
            int studiepoeng = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Maks antall studenter: ");
            int maksAntallStudenter = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Antall studenter: ");
            int antallStudenter = int.Parse(Console.ReadLine() ?? string.Empty);

            Kurs nyttKurs = new Kurs(kurskode, kursnavn, studiepoeng, antallStudenter, maksAntallStudenter);
            kursListe.Add(nyttKurs);

            Console.WriteLine("Kurs opprettet!");
        }

        static void MeldPå()
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine() ?? string.Empty;

            Console.Write("Studentnavn: ");
            string navn = Console.ReadLine() ?? string.Empty;

            Kurs? kurs = kursListe.Find(k => k.Kurskode == kode);
            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            kurs.MeldPå(new Student("X123", navn, "epost@uia.no"));
            Console.WriteLine("Student meldt på!");
        }

        static void PrintKursOgDeltagere()
        {
            foreach (var kurs in kursListe)
                kurs.PrintDetaljer();
        }

        static void SøkPåKurs()
        {
            Console.Write("\nSøk etter kurskode: ");
            string kode = Console.ReadLine() ?? string.Empty;

            Kurs? kurs = kursListe.Find(k => k.Kurskode == kode);

            if (kurs == null)
                Console.WriteLine("Fant ikke kurs.");
            else
                Console.WriteLine(kurs);
        }

        static void SøkPåBok()
        {
            Console.Write("\nSøk etter boktittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Bok? bok = bibliotek.FinnBok(tittel);

            if (bok == null)
                Console.WriteLine("Fant ikke bok.");
            else
                Console.WriteLine(bok);
        }

        static void LånBok()
        {
            Console.Write("\nBoktittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Bok? bok = bibliotek.FinnBok(tittel);

            bok?.LånUt();

        }

        static void ReturnerBok()
        {
            Console.Write("\nBoktittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Bok? bok = bibliotek.FinnBok(tittel);

            if (bok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            bok.LeverTilbake();
            Console.WriteLine("Bok returnert!");
        }

        static void RegistrerBok()
        {
            Console.Write("\nTittel: ");
            string tittel = Console.ReadLine() ?? string.Empty;

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine() ?? string.Empty;

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? string.Empty;

            Console.Write("År: ");
            int år = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Eksemplarer: ");
            int eksemplarer = int.Parse(Console.ReadLine() ?? string.Empty);

            bibliotek.LeggTilBok(new Bok(isbn, tittel, forfatter, år, eksemplarer));

            Console.WriteLine("Bok registrert!");
        }
    }
}
