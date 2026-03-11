

using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Universitet_System
{
    public class Kurs
    {
        public string Kurskode { get; set; }
        public string Kursnavn { get; set; }
        
        
        public int Studiepoeng { get; set; } 
        public int AntallStudenter { get; set; }
        public int MaxAntallStudenter { get; set; }


        public Kurs(string kurskode, string kursnavn, int studiepoeng, int antallstudenter, int maxantallstudenter)
        {
            Kurskode = kurskode;
            Kursnavn = kursnavn;
            Studiepoeng = studiepoeng;
            AntallStudenter = antallstudenter;
            MaxAntallStudenter = maxantallstudenter;
        }

        public void PrintDetaljer()
        {
            Console.WriteLine("Detaljer om kurset:");
            Console.WriteLine($"Kurskode: {Kurskode}");
            Console.WriteLine($"Kursnavn: {Kursnavn}");
            Console.WriteLine($"Studiepoeng: {Studiepoeng}");
            Console.WriteLine($"Antall studenter: {AntallStudenter}");
            Console.WriteLine($"Maks antall studenter: {MaxAntallStudenter}");
        }

        // Meldte på studenter
        public void MeldPå(Student student)
        {
            Console.WriteLine($"Dette er Antall studenter påmeldt {AntallStudenter}, det er max antall plasser {MaxAntallStudenter}");
            Console.Write("Hvor mange skal meldes på: ");
            int antall = int.Parse(Console.ReadLine() ?? string.Empty);

            if (AntallStudenter + antall <= MaxAntallStudenter)
            {
                AntallStudenter += antall;
                Console.WriteLine($"Meldt på {antall} studenter.");
            }
            else
            {
                Console.WriteLine($"Kan ikke melde på {antall} studenter. Maks antall studenter er {MaxAntallStudenter}.");
            }
        }
        public override string ToString()
        {
            return $"Kurs: {Kurskode} - {Kursnavn}, Studiepoeng: {Studiepoeng}, Antall påmeldte: {AntallStudenter}";
        }

    }

}
