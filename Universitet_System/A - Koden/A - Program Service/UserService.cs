using System;
using System.Collections.Generic;
using System.Linq;

namespace Universitet_System
{
    public class UserService
    {
        private readonly List<Bruker> _brukere;
        public List<Bruker> Brukere => _brukere;

        public UserService(List<Bruker> brukere)
        {
            _brukere = brukere;
        }

        public Bruker Login()
        {
            Console.Write("\nEpost: ");
            string epost = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(epost))
            {
                Console.WriteLine("Epost kan ikke være tom.");
                return null;
            }

            Console.Write("Passord: ");
            string pass = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Passord kan ikke være tomt.");
                return null;
            }

            var bruker = _brukere.FirstOrDefault(b =>
                b.Epost.Equals(epost, StringComparison.OrdinalIgnoreCase) &&
                b.SjekkPassord(pass));

            if (bruker == null)
                Console.WriteLine("Feil epost eller passord.");

            return bruker;
        }

        public Student RegistrerStudent()
        {
            string epost = ValiderEpost();

            Console.Write("Fullt navn: ");
            string navn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(navn))
            {
                Console.WriteLine("Navn kan ikke være tomt.");
                return null;
            }

            Console.Write("Passord: ");
            string pass = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Passord kan ikke være tomt.");
                return null;
            }

            var student = new Student(epost, pass, navn);
            _brukere.Add(student);

            Console.WriteLine($"Registrert som {student.StudentID}");
            return student;
        }

        public UtvekslingStudent RegistrerUtvekslingStudent()
        {
            string epost = ValiderEpost();

            Console.Write("Fullt navn: ");
            string navn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(navn))
            {
                Console.WriteLine("Navn kan ikke være tomt.");
                return null;
            }

            Console.Write("Passord: ");
            string pass = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Passord kan ikke være tomt.");
                return null;
            }

            Console.Write("Hjemuniversitet: ");
            string hjem = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(hjem))
            {
                Console.WriteLine("Hjemuniversitet kan ikke være tomt.");
                return null;
            }

            Console.Write("Land: ");
            string land = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(land))
            {
                Console.WriteLine("Land kan ikke være tomt.");
                return null;
            }

            DateTime fra;
            while (true)
            {
                Console.Write("Periode fra (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out fra)) break;
                Console.WriteLine("Ugyldig dato.");
            }

            DateTime til;
            while (true)
            {
                Console.Write("Periode til (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out til)) break;
                Console.WriteLine("Ugyldig dato.");
            }

            var student = new UtvekslingStudent(epost, pass, hjem, land, fra, til, navn);
            _brukere.Add(student);

            Console.WriteLine($"Registrert som {student.StudentID}");
            return student;
        }

        private string ValiderEpost()
        {
            while (true)
            {
                Console.Write("\nEpost: ");
                string epost = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(epost))
                {
                    Console.WriteLine("Epost kan ikke være tom.");
                    continue;
                }

                if (!epost.Contains("@") || !epost.Contains("."))
                {
                    Console.WriteLine("Ugyldig epost.");
                    continue;
                }

                if (_brukere.Any(b => b.Epost.Equals(epost, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Epost finnes allerede.");
                    continue;
                }

                return epost;
            }
        }
    }
}
