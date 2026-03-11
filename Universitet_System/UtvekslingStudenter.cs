using System;
using System.Collections.Generic;

namespace Universitet_System
{
    // Utvekslingsstudent arver fra Bruker
    public class UtvekslingStudent : Bruker
    {
        public string StudentID { get; set; }
        // Hjemuniversitet for utvekslingsoppholdet
        public string Hjemuniversitet { get; set; }
        public string Land { get; set; }

        // Periode for utveksling (fra - til)
        public DateTime? PeriodeFra { get; set; }
        public DateTime? PeriodeTil { get; set; }

        // Liste over kurs studenten er påmeldt i
        public List<Kurs> KursListe { get; } = new List<Kurs>();

        // lik Student men med ekstra felter
        public UtvekslingStudent(
            string studentID,
            string brukernavn,
            string epost,
            string hjemuniversitet = "",
            string land = "",
            DateTime? periodeFra = null,
            DateTime? periodeTil = null)
            : base(brukernavn, epost)
        {
            StudentID = studentID ?? string.Empty;
            Hjemuniversitet = hjemuniversitet ?? string.Empty;
            Land = land ?? string.Empty;
            PeriodeFra = periodeFra;
            PeriodeTil = periodeTil;
        }

        // Fin utskrift når vi skriver ut studenten
        public override string ToString()
        {
            string periode = "Ingen periode satt";
            if (PeriodeFra.HasValue || PeriodeTil.HasValue)
            {
                string fra = PeriodeFra?.ToString("yyyy-MM-dd") ?? "?";
                string til = PeriodeTil?.ToString("yyyy-MM-dd") ?? "?";
                periode = $"{fra} - {til}";
            }

            return $"Utvekslingsstudent: {Brukernavn} (ID: {StudentID}, Epost: {Epost}, Hjemuniversitet: {Hjemuniversitet}, Land: {Land}, Periode: {periode})";
        }
    }
}


