Uputstvo za pokretanje aplikacije:
Backend:
Za pokretanje backend aplikacije, ući u folder BloodBank, otvoriti BloodBank.sln u Visual Studiu
(za izradu projekta korišćen je Visual Studio 2022). Potrebno je preuzeti i instalirati SQL Server 2022 Express sa sledećeg linka: https://www.microsoft.com/en-us/sql-server/sql-server-downloads.
U "Repository" sloju ući u folder "DatabaseContext" i otvoriti "DataContext.cs" u kojem je potrebno promeniti Connection string na "Server=localhost\SQLEXPRESS;Database=isadb;Trusted_Connection=True;".
U package manager konzoli, komandom "cd Repository" ući uodgovarajući direktorijum. Izvršiti komandu "dotnet tool install --global dotnet-ef" a potom "dotnet tool update --global dotnet-ef".
Zatim izvršiti komandu "dotnet ef database update" kako bi se baza popunila test podacima.
Nakon sto je komanda izvršena, pokrenuti aplikaciju.

Frontend:
Za pokretanje frontend aplikacije, potrebno je pokrenuti fajl "run_react_app.ps1" pomoću PowerShell-a.
