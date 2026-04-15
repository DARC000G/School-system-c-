using System;
using System.Collections.Generic;

namespace Universitet_System
{
    internal class Program
    {
        private static void Main()
        {
            var student = new Student("student@uni.no", "123", "Test Student");
            var fag = new Faglaerer("fag@uni.no", "123", "IT");
            var bib = new BibliotekAnsatt("bib@uni.no", "123", "Hovedbibliotek");

            var brukere = new List<Bruker> { student, fag, bib };

            var kursListe = new List<Kurs>
            {
                new Kurs("IT101", "Innføring i IT", fag, 30),
                new Kurs("IT102", "Objektorientert Programmering", fag, 25)
            };

            var bibliotek = new Bibliotek();
            bibliotek.LeggTilBok(new Bok("9788205501234", "C# for nybegynnere", "Hansen", 2020, 5));
            bibliotek.LeggTilBok(new Bok("9788205505676", "Algoritmer og datastrukturer", "Olsen", 2019, 3));

            var userService = new UserService(brukere);
            var courseService = new CourseService(kursListe);
            var libraryService = new LibraryService(bibliotek);
            var menuService = new MenuService(userService, courseService, libraryService);

            while (true)
            {
                var bruker = menuService.HovedMeny();
                if (bruker == null)
                    break;

                switch (bruker)
                {
                    case Student s:
                        menuService.StudentMeny(s);
                        break;

                    case Faglaerer f:
                        menuService.FaglaererMeny(f);
                        break;

                    case BibliotekAnsatt b:
                        menuService.BibliotekMeny(b);
                        break;
                }
            }

            Console.WriteLine("Program avsluttet.");
        }
    }
}
