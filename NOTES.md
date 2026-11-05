# CSE 325 — Week 01 Assignment Notes

**Student:** Sammy  
**Course:** CSE 325 .NET Software Development (BYU-Idaho)  
**Assignment:** W01 — Build .NET Applications with C#

Base URL used for testing: `http://localhost:5247` (from `ContosoPizza/Properties/launchSettings.json`, HTTP profile). Restart the API after code changes before re-testing.

---

## 1. Additional Pizza Evidence

**File:** `Week 1/ContosoPizza/Services/PizzaService.cs`

Added a third seed pizza: **BBQ Chicken** (Id 3). Seed list also includes Classic Italian (1) and Veggie (2).

**Request:**

```http
GET http://localhost:5247/pizza
Accept: application/json
```

**Status code:** `200 OK`

**Response:**

```json
[
  { "id": 1, "name": "Classic Italian", "isGlutenFree": false },
  { "id": 2, "name": "Veggie", "isGlutenFree": true },
  { "id": 3, "name": "BBQ Chicken", "isGlutenFree": false }
]
```

---

## 2. API CRUD Testing

### GET — Read all pizzas

**Request:**

```http
GET http://localhost:5247/pizza
Accept: application/json
```

**Status code:** `200 OK`

**Response:**

```json
[
  { "id": 1, "name": "Classic Italian", "isGlutenFree": false },
  { "id": 2, "name": "Veggie", "isGlutenFree": true },
  { "id": 3, "name": "BBQ Chicken", "isGlutenFree": false }
]
```

### POST — Create pizza

**Request:**

```http
POST http://localhost:5247/pizza
Content-Type: application/json

{
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

**Status code:** `201 Created`

**Response:**

```json
{
  "id": 4,
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

The server assigns Id **4** because seed data uses Ids 1–3 and `nextId` starts at 4.

### PUT — Update pizza

**Request:** (updates the pizza created by POST above)

```http
PUT http://localhost:5247/pizza/4
Content-Type: application/json

{
  "id": 4,
  "name": "Hawaiian Deluxe",
  "isGlutenFree": false
}
```

**Status code:** `204 No Content`

**Response:** No response body (expected for 204).

### DELETE — Remove pizza

**Request:**

```http
DELETE http://localhost:5247/pizza/4
```

**Status code:** `204 No Content`

**Response:** No response body (expected for 204).

After DELETE, `GET http://localhost:5247/pizza` again returns only the three seed pizzas (Ids 1–3).

---

## 3. Sales Summary Function

**File:** `Week 1/FilesAndDirectories/mslearn-dotnet-files/Program.cs`

**Output file:** `Week 1/FilesAndDirectories/mslearn-dotnet-files/stores/sales-summary.txt`

**Working C# function:**

```csharp
void GenerateSalesSummaryReport(IEnumerable<string> salesJsonFilePaths, string outputFilePath)
{
    var report = new StringBuilder();
    var details = new List<(string FilePath, decimal Total)>();
    decimal grandTotal = 0m;

    foreach (string path in salesJsonFilePaths)
    {
        string json = File.ReadAllText(path);
        SalesData? data = JsonSerializer.Deserialize<SalesData>(json);

        if (data is null)
            throw new InvalidDataException($"Could not read sales total from: {path}");

        details.Add((path, data.Total));
        grandTotal += data.Total;
    }

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($" Total Sales: {grandTotal:C}");
    report.AppendLine();
    report.AppendLine(" Details:");

    foreach (var (filePath, total) in details)
        report.AppendLine($"  {filePath}: {total:C}");

    File.WriteAllText(outputFilePath, report.ToString());
}

class SalesData
{
    public decimal Total { get; set; }
}
```

**Sample generated report** (from `dotnet run` in the files project):

```text
Sales Summary
----------------------------
 Total Sales: $2,012.20

 Details:
  stores\sales.json: $88.88
  stores\201\sales.json: $501.22
  stores\202\sales.json: $1,234.22
  stores\203\sales.json: $99.00
  stores\204\sales.json: $88.88
```
