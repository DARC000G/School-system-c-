School-system-c-
│
├── Universitet_System/              ← hovedprosjektet
│   ├── A - Koden/
│   │   ├── A - Program/
│   │   │   └── Program.cs
│   │   └── A - Program Service/
│   │       ├── UserService.cs
│   │       ├── CourseService.cs
│   │       ├── LibraryService.cs
│   │       └── MenuService.cs
│   │
│   ├── B - Personer/
│   │   ├── Bruker.cs
│   │   ├── Student.cs
│   │   ├── UtvekslingStudenter.cs
│   │   ├── Ansatt.cs
│   │   ├── Faglærer.cs
│   │   └── BibliotekAnsatt.cs
│   │
│   ├── C - Funksjonalitet/
│   │   ├── Bok.cs
│   │   ├── Bibliotek.cs
│   │   ├── Kurs.cs
│   │   ├── Lån.cs
│   │   └── Rolle.cs
│   │
│   └── Helloworld.csproj
│
├── Universitet_System.Tests/        ← enhetstester
│   ├── BasicTest.cs
│   └── Universitet_System.Tests.csproj
│
└── README.md


Forklaring av mappene:

A – Program
Inneholder Program.cs, som:

Starter applikasjonen

Initialiserer dummy‑data

Sender brukeren videre til riktig meny basert på rolle

_________________________________________________________________

A – Program Service
Service‑laget som håndterer all logikk:

UserService – innlogging, registrering, brukerhåndtering

CourseService – kursadministrasjon

LibraryService – bibliotekfunksjoner

MenuService – alle menyene

_________________________________________________________________

B – Personer
Alle brukerklassene:

Bruker (abstrakt baseklasse)

Student

Utvekslingsstudent

Ansatt

Faglærer

BibliotekAnsatt

Rolle‑enum

_________________________________________________________________

C – Funksjonalitet
Alle objekter i systemet:

Bok – representerer en bok

Bibliotek – håndterer bøker og lån

Kurs – kursinformasjon og påmeldinger

Lån – representerer et boklån

_________________________________________________________________

Funksjonalitet
👤 Brukerroller
Student
Se kurs

Melde på/av kurs

Låne og returnere bøker

Se egne lån

Faglærer
Se kurs

Legge til pensum

Sette karakterer

Bibliotekansatt
Administrere bøker

Administrere lån

_________________________________________________________________


📚 Bibliotek
Søk etter bøker

Låne og levere

Se alle bøker

Hindre dobbeltlån

_________________________________________________________________


🎓 Kurs
Påmelding / avmelding

Pensum

Karakterer

Maks antall studenter

_________________________________________________________________


🛠️ Teknologi
C# / .NET 10

Konsollapplikasjon

Objektorientert programmering

Service‑lag

Ryddig og modulær mappestruktur

_________________________________________________________________


🧪 Enhetstester
Prosjektet inkluderer et eget testprosjekt (Universitet_System.Tests) med totalt 4 enhetstester.
Alle testene kjører grønt.

Testene dekker:

Påmelding til kurs

Hindre duplikatkurs

Lån av bøker (hindre dobbeltlån)

Registrering av bøker

_________________________________________________________________

Hvordan kjøre prosjektet:
Åpne prosjektet i Visual Studio eller VS Code

Naviger til Universitet_System

Kjør Program.cs

Logg inn med en av dummy‑brukerne eller registrer en ny

Systemet guider deg videre basert på rolle