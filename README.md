# 🎓 Universitet System – Konsollapplikasjon (C#)

Et komplett og ryddig universitetsadministrasjonssystem utviklet i C#.  
Prosjektet er strukturert i flere mapper for å gjøre koden oversiktlig, lett å vedlikeholde og enkel å utvide.

Systemet støtter:
- Innlogging og registrering av brukere
- Roller: Student, Utvekslingsstudent, Faglærer, Bibliotekansatt
- Kursadministrasjon (påmelding, avmelding, pensum, karakterer)
- Bibliotekfunksjoner (søk, lån, levering)
- Menyer basert på brukerrolle

---

## 📁 Prosjektstruktur

Prosjektet er organisert i tre hovedmapper + Program:


---

## 🧩 Kort forklaring av mappene

### **A – Program**
Inneholder hovedprogrammet (`Program.cs`) som starter applikasjonen, initialiserer data og ruter brukeren til riktig meny basert på rolle.

### **A – Program service**
Inneholder all logikk som tidligere lå i Program.cs:
- **UserService** – innlogging og registrering  
- **CourseService** – kursadministrasjon  
- **LibraryService** – bibliotekfunksjoner  
- **MenuService** – alle menyene (student, lærer, bibliotek)

Dette gjør Program.cs kort og profesjonelt.

### **B – Personer**
Alle klasser som representerer brukere:
- Bruker (abstrakt)
- Student og UtvekslingStudent
- Ansatt, Faglærer og BibliotekAnsatt
- Rolle‑enum

### **C – Funksjonalitet**
Alt som ikke er personer:
- Bok
- Bibliotek
- Kurs
- Lån

---

## 🚀 Funksjonalitet

### 👤 **Brukerroller**
- **Student**  
  - Se kurs  
  - Melde på/av kurs  
  - Låne/returnere bøker  
  - Se egne lån  

- **Faglærer**  
  - Se kurs  
  - Legge til pensum  
  - Sette karakterer  

- **Bibliotekansatt**  
  - Administrere lån og bøker  

### 📚 **Bibliotek**
- Søk etter bøker  
- Låne og levere  
- Se alle bøker  

### 🎓 **Kurs**
- Påmelding / avmelding  
- Pensum  
- Karakterer  

---

## 🛠️ Teknologi

- **C#**
- **.NET Console Application**
- Objektorientert programmering
- Ryddig mappestruktur og service‑lag

---

## 🧪 Dummy‑data

Prosjektet inkluderer enkel testdata i `Seed()`‑metoden i Program.cs:
- 1 student  
- 1 faglærer  
- 1 bibliotekansatt  
- 2 kurs  
- 2 bøker  

Dette gjør det enkelt å teste systemet uten å registrere alt manuelt.

---

## 📌 Hvordan kjøre prosjektet

1. Åpne prosjektet i Visual Studio eller VS Code  
2. Kjør `Program.cs`  
3. Logg inn med en av dummy‑brukerne eller registrer en ny  
4. Systemet guider deg videre basert på rolle  

---

## 🏁 Status

Prosjektet er **komplett**, ryddig strukturert og klart for innlevering eller videre utvikling.

