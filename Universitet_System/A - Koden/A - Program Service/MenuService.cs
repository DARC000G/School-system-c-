using System;

namespace Universitet_System
{
    public class MenuService
    {
        private readonly UserService _userService;
        private readonly CourseService _courseService;
        private readonly LibraryService _libraryService;

        public MenuService(UserService u, CourseService c, LibraryService l)
        {
            _userService = u;
            _courseService = c;
            _libraryService = l;
        }

        public Bruker HovedMeny()
        {
            while (true)
            {
                Console.WriteLine("\n=== HOVEDMENY ===");
                Console.WriteLine("1) Jeg har allerede bruker (logg inn)");
                Console.WriteLine("2) Jeg er ny student (registrer)");
                Console.WriteLine("3) Jeg er ny utvekslingsstudent (registrer)");
                Console.WriteLine("0) Avslutt");
                Console.Write("> ");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        return _userService.Login();

                    case "2":
                        return _userService.RegistrerStudent();

                    case "3":
                        return _userService.RegistrerUtvekslingStudent();

                    case "0":
                        return null;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }
            }
        }

        public void StudentMeny(Student s)
        {
            while (true)
            {
                Console.WriteLine($"\nInnlogget som: {s.StudentID} - Student - {s.FulltNavn}");
                Console.WriteLine("1) Kurs");
                Console.WriteLine("2) Bibliotek");
                Console.WriteLine("0) Logg ut");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": StudentKursMeny(s); break;
                    case "2": StudentBibliotekMeny(s); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void StudentKursMeny(Student s)
        {
            while (true)
            {
                Console.WriteLine("\n=== KURS (Student) ===");
                Console.WriteLine("1) Se alle kurs");
                Console.WriteLine("2) Meld på kurs");
                Console.WriteLine("3) Meld av kurs");
                Console.WriteLine("4) Mine kurs");
                Console.WriteLine("5) Mine karakterer");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _courseService.VisAlleKurs(); break;
                    case "2": _courseService.MeldPåKurs(s); break;
                    case "3": _courseService.MeldAvKurs(s); break;
                    case "4": _courseService.VisStudentKurs(s); break;
                    case "5": _courseService.VisStudentKarakterer(s); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void StudentBibliotekMeny(Student s)
        {
            while (true)
            {
                Console.WriteLine("\n=== BIBLIOTEK (Student) ===");
                Console.WriteLine("1) Søk bok");
                Console.WriteLine("2) Vis alle bøker");
                Console.WriteLine("3) Lån bok");
                Console.WriteLine("4) Returner bok");
                Console.WriteLine("5) Mine lån");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _libraryService.SøkBok(); break;
                    case "2": _libraryService.VisAlleBøker(); break;
                    case "3": _libraryService.LånBok(s); break;
                    case "4": _libraryService.ReturnerBok(s); break;
                    case "5": _libraryService.VisMineLån(s); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        public void FaglaererMeny(Faglaerer f)
        {
            while (true)
            {
                Console.WriteLine($"\nInnlogget som: {f.Epost} - Faglærer");
                Console.WriteLine("1) Kurs");
                Console.WriteLine("2) Bibliotek");
                Console.WriteLine("0) Logg ut");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": FaglaererKursMeny(f); break;
                    case "2": FaglaererBibliotekMeny(f); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void FaglaererKursMeny(Faglaerer f)
        {
            while (true)
            {
                Console.WriteLine("\n=== KURS (Faglærer) ===");
                Console.WriteLine("1) Se alle kurs");
                Console.WriteLine("2) Søk kurs");
                Console.WriteLine("3) Opprett kurs");
                Console.WriteLine("4) Legg til pensum");
                Console.WriteLine("5) Sett/endre karakter");
                Console.WriteLine("6) Vis alle studenter");
                Console.WriteLine("7) Vis studenter i et kurs");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _courseService.VisAlleKurs(); break;
                    case "2": _courseService.SøkKurs(); break;
                    case "3": _courseService.OpprettKurs(f); break;
                    case "4": _courseService.LeggTilPensum(f); break;
                    case "5": _courseService.SettKarakter(f); break;
                    case "6": _courseService.VisAlleStudenter(_userService.Brukere); break;
                    case "7": _courseService.VisStudenterIKurs(f); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void FaglaererBibliotekMeny(Faglaerer f)
        {
            while (true)
            {
                Console.WriteLine("\n=== BIBLIOTEK (Faglærer) ===");
                Console.WriteLine("1) Søk bok");
                Console.WriteLine("2) Vis alle bøker");
                Console.WriteLine("3) Lån bok");
                Console.WriteLine("4) Returner bok");
                Console.WriteLine("5) Mine lån");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _libraryService.SøkBok(); break;
                    case "2": _libraryService.VisAlleBøker(); break;
                    case "3": _libraryService.LånBok(f); break;
                    case "4": _libraryService.ReturnerBok(f); break;
                    case "5": _libraryService.VisMineLån(f); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        public void BibliotekMeny(BibliotekAnsatt b)
        {
            while (true)
            {
                Console.WriteLine($"\nInnlogget som: {b.Epost} - Bibliotekansatt");
                Console.WriteLine("1) Bøker");
                Console.WriteLine("2) Lån og historikk");
                Console.WriteLine("0) Logg ut");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": BibliotekarBokMeny(b); break;
                    case "2": BibliotekarLånMeny(b); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void BibliotekarBokMeny(BibliotekAnsatt b)
        {
            while (true)
            {
                Console.WriteLine("\n=== BØKER (Bibliotekar) ===");
                Console.WriteLine("1) Søk bok");
                Console.WriteLine("2) Vis alle bøker");
                Console.WriteLine("3) Lån bok");
                Console.WriteLine("4) Returner bok");
                Console.WriteLine("5) Mine lån");
                Console.WriteLine("6) Registrer ny bok");
                Console.WriteLine("7) Endre bok");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _libraryService.SøkBok(); break;
                    case "2": _libraryService.VisAlleBøker(); break;
                    case "3": _libraryService.LånBok(b); break;
                    case "4": _libraryService.ReturnerBok(b); break;
                    case "5": _libraryService.VisMineLån(b); break;
                    case "6": _libraryService.RegistrerNyBok(); break;
                    case "7": _libraryService.EndreBok(); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }

        private void BibliotekarLånMeny(BibliotekAnsatt b)
        {
            while (true)
            {
                Console.WriteLine("\n=== LÅN (Bibliotekar) ===");
                Console.WriteLine("1) Se aktive lån");
                Console.WriteLine("2) Se lånehistorikk");
                Console.WriteLine("0) Tilbake");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": _libraryService.VisAlleAktiveLån(); break;
                    case "2": _libraryService.VisLånehistorikk(); break;
                    case "0": return;
                    default: Console.WriteLine("Ugyldig valg."); break;
                }
            }
        }
    }
}
