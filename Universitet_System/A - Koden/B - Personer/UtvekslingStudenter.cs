using System;

namespace Universitet_System
{
    public class UtvekslingStudent : Student
    {
        public string HjemUniversitet { get; }
        public string Land { get; }
        public DateTime PeriodeFra { get; }
        public DateTime PeriodeTil { get; }

        public UtvekslingStudent(
            string epost,
            string passord,
            string hjemUniversitet,
            string land,
            DateTime fra,
            DateTime til,
            string fulltNavn = "Utvekslingsstudent")
            : base(epost, passord, fulltNavn)
        {
            HjemUniversitet = hjemUniversitet;
            Land = land;
            PeriodeFra = fra;
            PeriodeTil = til;

            // Overstyr ID til US-prefiks
            StudentID = $"US{_teller:D4}";
            _teller++;
        }

        public override string ToString()
            => $"{StudentID} - {Epost} (Utveksling, {HjemUniversitet}, {Land})";
    }
}
