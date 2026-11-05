# CSE 325 — Week 01 Assignment

**Course:** CSE 325 .NET Software Development (BYU-Idaho)  
**Assignment:** W01 — Build .NET Applications with C#  
**Learning path:** [Build .NET Applications with C#](https://learn.microsoft.com/en-us/training/paths/build-dotnet-applications-csharp/)

Repository for Week 1 Microsoft Learn modules and assignment artifacts.

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (LTS — .NET 10 for most projects; files lab uses net8.0 per Learn)

```bash
dotnet --version
dotnet --list-sdks
```

- Visual Studio Code (REST Client extension optional for `ContosoPizza.http`)

---

## Repository layout

```
Week 1/
├── Introducing .NET/MyConsoleApp/
├── FilesAndDirectories/mslearn-dotnet-files/
└── ContosoPizza/
```

Root: `MyConsoleApp.slnx`, `README.md`, `NOTES.md` (submission notes)

---

## Run instructions

### MyConsoleApp

```bash
cd "Week 1/Introducing .NET/MyConsoleApp"
dotnet run
```

### mslearn-dotnet-files

```bash
cd "Week 1/FilesAndDirectories/mslearn-dotnet-files"
dotnet run
```

Generates `stores/sales-summary.txt` from all `sales.json` files under `stores/`.

### ContosoPizza API

```bash
cd "Week 1/ContosoPizza"
dotnet run
```

Use the URL shown in the terminal (see `Properties/launchSettings.json`). Default HTTP profile:

```text
http://localhost:5247
```

Endpoints: `/pizza`, `/weatherforecast`

---

## Assignment highlights

**Extra seed pizza** (`Services/PizzaService.cs`): BBQ Chicken (Id 3). `nextId` is 4 for new POST requests.

**Sales summary** (`mslearn-dotnet-files/Program.cs`): `GenerateSalesSummaryReport` writes formatted totals to `stores/sales-summary.txt`.

**API testing:** `ContosoPizza.http` or browser/curl. See `NOTES.md` for GET/POST/PUT/DELETE request, response, and status codes required for submission.

---

## Learn modules (order)

1. Write your first C# code  
2. Introduction to .NET  
3. Create a new .NET project and work with dependencies  
4. Interactively debug .NET apps with the VS Code debugger  
5. Work with files and directories in a .NET app  
6. Create a web API with ASP.NET Core controllers  

---

## Submission

Submit repo link plus `NOTES.md` at repo root with:

1. GET `/pizza` showing seed data (including additional pizza)  
2. CRUD examples with status codes  
3. Sales summary function source  

---

Sammy — CSE 325, Term 12 2026
