using System;
using System.Collections.Generic;

namespace Universitet_System
{
    class Program
    {
        static List<Kurs> kursListe = new List<Kurs>();
        static Bibliotek bibliotek = new Bibliotek();
        static List<Student> studentListe = new List<Student>();
        static List<Ansatt> ansattListe = new List<Ansatt>();

        static void Main(string[] args)
        {
            // Testdata
            studentListe.Add(new Student("S123", "Ola Nordmann", "ola.nordmann@uia.no"));
            studentListe.Add(new Student("S124", "Kari Nordmann", "kari.nordmann@uia.no"));
            studentListe.Add(new Student("S125", "Per Hansen", "per.hansen@uia.no"));

            bibliotek.LeggTilBok(new Bok("978-3-16-148410-0", "C# Programmering", "Forfatter A", 2020, 69));
            bibliotek.LeggTilBok(new Bok("978-1-23-456789-7", "Læring av maskiner", "Forfatter B", 2021, 24));
            bibliotek.LeggTilBok(new Bok("978-0-12-345678-9", "Databaser for utviklere", "Forfatter C", 2019, 100));

            while (true)
            {
                Console.WriteLine("\n=== Universitet System ===");
                Console.WriteLine("1. Opprett kurs");
                Console.WriteLine("2. Meld student til kurs");
                Console.WriteLine("3. Print kurs og deltagere");
                Console.WriteLine("4. Søk på kurs");
                Console.WriteLine("5. Søk på bok");
                Console.WriteLine("6. Lån bok");
                Console.WriteLine("7. Returner bok");
                Console.WriteLine("8. Registrer bok");
                Console.WriteLine("9. Registrer bruker");
                Console.WriteLine("0. Avslutt");

                Console.Write("\nVelg et alternativ: ");
                string valg = Console.ReadLine() ?? "";

                if (valg == "0")
                    break;

                if (valg == "1") OpprettKurs();
                else if (valg == "2") MeldPå();
                else if (valg == "3") PrintKursOgDeltagere();
                else if (valg == "4") SøkPåKurs();
                else if (valg == "5") SøkPåBok();
                else if (valg == "6") LånBok();
                else if (valg == "7") ReturnerBok();
                else if (valg == "8") RegistrerBok();
                else if (valg == "9") RegistrerBruker();
                else Console.WriteLine("Ugyldig valg.");
            }
        }

        // ===============================
        // 1. Opprett kurs
        // ===============================
        static void OpprettKurs()
        {
            Console.Write("\nKursnavn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Kurskode: ");
            string kode = Console.ReadLine() ?? "";

            Console.Write("Studiepoeng: ");
            int studiepoeng;
            int.TryParse(Console.ReadLine(), out studiepoeng);

            Console.Write("Maks antall studenter: ");
            int maks;
            int.TryParse(Console.ReadLine(), out maks);

            Kurs nyttKurs = new Kurs(kode, navn, studiepoeng, maks);
            kursListe.Add(nyttKurs);

            Console.WriteLine("Kurs opprettet!");
        }

        // ===============================
        // 2. Meld student på kurs
        // ===============================
        static void MeldPå()
        {
            Console.Write("\nKurskode: ");
            string kode = Console.ReadLine() ?? "";

            Console.Write("Studentnavn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Skriv 'avmeld' for å melde av, ellers Enter: ");
            string avmeld = Console.ReadLine() ?? "";

            Kurs kurs = null;
            foreach (Kurs k in kursListe)
            {
                if (k.Kurskode == kode)
                {
                    kurs = k;
                    break;
                }
            }

            Student student = null;
            foreach (Student s in studentListe)
            {
                if (s.Brukernavn == navn)
                {
                    student = s;
                    break;
                }
            }

            if (kurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            if (student == null)
            {
                Console.WriteLine("Fant ikke student.");
                return;
            }

            if (avmeld.ToLower() == "avmeld")
            {
                kurs.MeldAv(student);
                student.KursListe.Remove(kurs);
                Console.WriteLine("Student avmeldt.");
                return;
            }

            kurs.MeldPå(student);
            student.KursListe.Add(kurs);
            Console.WriteLine("Student påmeldt!");
        }

        // ===============================
        // 3. Print kurs og deltagere
        // ===============================
        static void PrintKursOgDeltagere()
        {
            foreach (Kurs kurs in kursListe)
            {
                kurs.PrintDetaljer();
                Console.WriteLine("Deltagere:");

                if (kurs.Deltakere.Count == 0)
                {
                    Console.WriteLine("Ingen deltagere.");
                }
                else
                {
                    foreach (Student s in kurs.Deltakere)
                        Console.WriteLine(" - " + s.Brukernavn);
                }

                Console.WriteLine();
            }
        }

        // ===============================
        // 4. Søk på kurs
        // ===============================
        static void SøkPåKurs()
        {
            Console.Write("\nSøk etter kurs: ");
            string søk = Console.ReadLine() ?? "";

            List<Kurs> funn = new List<Kurs>();

            foreach (Kurs k in kursListe)
            {
                if (k.Kurskode.Contains(søk) || k.Kursnavn.Contains(søk))
                {
                    funn.Add(k);
                }
            }

            if (funn.Count == 0)
            {
                Console.WriteLine("Fant ingen kurs.");
                return;
            }

            foreach (Kurs k in funn)
                Console.WriteLine(k);
        }

        // ===============================
        // 5. Søk på bok
        // ===============================
        static void SøkPåBok()
        {
            Console.Write("\nSøk etter boktittel eller skriv 'vis alle': ");
            string tittel = Console.ReadLine() ?? "";

            if (tittel == "" || tittel.ToLower() == "vis alle")
            {
                bibliotek.VisAlleBøker();
                return;
            }

            Bok bok = bibliotek.FinnBok(tittel);

            if (bok == null)
                Console.WriteLine("Fant ikke bok.");
            else
                Console.WriteLine(bok);
        }

        // ===============================
        // 6. Lån bok (KUN TITTEL)
        // ===============================
        static void LånBok()
        {
            Console.Write("\nBoktittel: ");
            string tittel = Console.ReadLine() ?? "";

            Bok bok = bibliotek.FinnBok(tittel);

            if (bok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            if (bok.AntallEksemplarer <= 0)
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig.");
                return;
            }

            Console.Write("Navn på låner: ");
            string navn = Console.ReadLine() ?? "";

            Bruker bruker = null;

            foreach (Student s in studentListe)
            {
                if (s.Brukernavn == navn)
                {
                    bruker = s;
                    break;
                }
            }

            if (bruker == null)
            {
                foreach (Ansatt a in ansattListe)
                {
                    if (a.Brukernavn == navn)
                    {
                        bruker = a;
                        break;
                    }
                }
            }

            if (bruker == null)
            {
                Console.WriteLine("Fant ikke bruker.");
                return;
            }

            Lån lån = new Lån(bok, bruker);
            bibliotek.LånListe.Add(lån);

            bok.AntallEksemplarer--;

            Console.WriteLine("Bok lånt ut!");
        }

        // ===============================
        // 7. Returner bok (KUN TITTEL)
        // ===============================
        static void ReturnerBok()
        {
            Console.Write("\nBoktittel: ");
            string tittel = Console.ReadLine() ?? "";

            if (bibliotek.FinnBok(tittel) == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            Lån lån = null;

            foreach (Lån l in bibliotek.LånListe)
            {
                if (l.Bok == bibliotek.FinnBok(tittel) && l.Aktiv)
                {
                    lån = l;
                    break;
                }
            }

            if (lån == null)
            {
                Console.WriteLine("Fant ikke aktivt lån.");
                return;
            }

            lån.Returner();
            bibliotek.FinnBok(tittel).AntallEksemplarer++;

            Console.WriteLine("Bok returnert!");
        }

        // ===============================
        // 8. Registrer bok
        // ===============================
        static void RegistrerBok()
        {
            Console.Write("\nISBN: ");
            string isbn = Console.ReadLine() ?? "";

            Console.Write("Tittel: ");
            string tittel = Console.ReadLine() ?? "";

            Console.Write("Forfatter: ");
            string forfatter = Console.ReadLine() ?? "";

            Console.Write("År: ");
            int år;
            int.TryParse(Console.ReadLine(), out år);

            Console.Write("Antall eksemplarer: ");
            int antall;
            int.TryParse(Console.ReadLine(), out antall);

            Bok ny = new Bok(isbn, tittel, forfatter, år, antall);
            bibliotek.LeggTilBok(ny);

            Console.WriteLine("Bok registrert!");
        }

        // ===============================
        // 9. Registrer bruker
        // ===============================
        static void RegistrerBruker()
        {
            Console.WriteLine("\n1. Student");
            Console.WriteLine("2. Utvekslingsstudent");
            Console.WriteLine("3. Ansatt");
            Console.Write("Valg: ");

            string valg = Console.ReadLine() ?? "";

            if (valg == "1") RegistrerStudent();
            else if (valg == "2") RegistrerUtvekslingsstudent();
            else if (valg == "3") RegistrerAnsatt();
            else Console.WriteLine("Ugyldig valg.");
        }

        static void RegistrerStudent()
        {
            Console.Write("\nStudentID: ");
            string id = Console.ReadLine() ?? "";

            Console.Write("Navn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Epost: ");
            string epost = Console.ReadLine() ?? "";

            studentListe.Add(new Student(id, navn, epost));
            Console.WriteLine("Student registrert!");
        }

        static void RegistrerUtvekslingsstudent()
        {
            Console.Write("\nStudentID: ");
            string id = Console.ReadLine() ?? "";

            Console.Write("Navn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Epost: ");
            string epost = Console.ReadLine() ?? "";

            Console.Write("Hjemuniversitet: ");
            string hjem = Console.ReadLine() ?? "";

            Console.Write("Land: ");
            string land = Console.ReadLine() ?? "";

            Console.Write("Periode fra (dd.mm.yyyy): ");
            DateTime fra = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Periode til (dd.mm.yyyy): ");
            DateTime til = DateTime.Parse(Console.ReadLine() ?? "");

            studentListe.Add(new UtvekslingStudent(id, navn, epost, hjem, land, fra, til));
            Console.WriteLine("Utvekslingsstudent registrert!");
        }

        static void RegistrerAnsatt()
        {
            Console.Write("\nAnsattID: ");
            string id = Console.ReadLine() ?? "";

            Console.Write("Navn: ");
            string navn = Console.ReadLine() ?? "";

            Console.Write("Epost: ");
            string epost = Console.ReadLine() ?? "";

            Console.Write("Stilling: ");
            string stilling = Console.ReadLine() ?? "";

            Console.Write("Avdeling: ");
            string avdeling = Console.ReadLine() ?? "";

            ansattListe.Add(new Ansatt(id, navn, epost, stilling, avdeling));
            Console.WriteLine("Ansatt registrert!");
        }
    }
}