# Insurance Premium Calculator (ASP.NET Core MVC)

## Overview
This project calculates monthly insurance premiums using MVC architecture, Repository Pattern, and Dependency Injection.

---

##  Architecture Diagram
```
+-------------------+
|   Controllers     |
| PremiumController |
+--------+----------+
         |
         v
+--------+----------+
|      Services     |
| InsuranceCalculator|
+--------+----------+
         |
         v
+--------+----------+
|    Repository     |
| OccupationRepositoryMock |
+--------+----------+
         |
         v
+--------+----------+
|      Models       |
| InsuranceInput,   |
| Occupation,       |
| RatingFactors     |
+-------------------+
```

---

## Setup Instructions
1. Install .NET 9.0.10+
2. Clone repo
3. Run:
```bash
dotnet build
dotnet run
```
Access: `http://localhost:5000/Premium/Index`

---

##  Usage
Fill form → Submit → Premium displayed on same page.

---

##  Tests
Run:
```bash
dotnet test
```

---

##  Patterns Used
- MVC
- Repository Pattern
- Dependency Injection
