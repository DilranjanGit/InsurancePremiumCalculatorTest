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

## Unit Tests

Unit tests are located in the `Tests` folder:
- `InsuranceCalculatorTests.cs`: Tests the core premium calculation logic, including:
  - Valid input returns correct premium value
  - Invalid occupation throws exception
- `PremiumControllerTests.cs`: Tests the controller logic, including:
  - Posting valid input returns a view with the calculated premium

### How to Run Tests
Run all tests using:
```bash
dotnet test
```

Tests use [xUnit](https://xunit.net/) and [Moq](https://github.com/moq/moq4) for mocking dependencies.

---

## UI Validation

The application uses both client-side and server-side validation to ensure data integrity:

- **Client-side validation:**
  - All form fields in the UI are marked as `required` for basic browser validation.
  - Numeric fields (e.g., Age, Death Sum Insured) use `type="number"` for input constraints.
- **Server-side validation:**
  - The `InsuranceInput` model uses `[Required]` and `[Range]` data annotations to enforce validation rules.
  - The controller checks `ModelState.IsValid` before processing input. If validation fails, the form is redisplayed with errors.

**Validation rules include:**
- Name: Required
- Age Next Birthday: Required, must be between 1 and 120
- Date of Birth: Required
- Occupation Rating: Required
- Death Sum Insured: Required, must be greater than 0

If validation fails, the user is prompted to correct the input before premium calculation proceeds.

---

##  Patterns Used
- MVC
- Repository Pattern
- Dependency Injection
