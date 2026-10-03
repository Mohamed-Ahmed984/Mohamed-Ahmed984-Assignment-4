# Academy Schedule Analyzer

Student Name: Not provided in the uploaded files.

Cohort: Not provided in the uploaded files.

Assignment: [S1-A4] Assignment 4

## Project

`AcademyScheduleAnalyzer/`

The project targets .NET 9 and uses BenchmarkDotNet 0.15.8, preserving the supplied package version. Install the .NET 9 SDK and restore the project dependencies before running it.

From the repository root:

```bash
dotnet restore AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj
dotnet build submission/assignment/Assignment4.sln -c Release
dotnet run --project AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj
```

The console menu demonstrates schedule arrays, searches, duration analysis, date/time operations, parameter passing, reports and exception handling. Enter session names exactly as shown in the starter data. The menu repeats until option 0 is selected.

## LeetCode

[Problem links, explanations and supplied screenshots](LeetCode/README.md)

LeetCode Profile: https://leetcode.com/u/7V5DqS2LTd/

[Account submission file](submission/leetcode/account.md)

Full accepted Submit records still require verification.

## Benchmark

[BENCHMARK.md](BENCHMARK.md)

Run the benchmark separately from the console application:

```bash
dotnet run --project AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj -c Release -- --benchmark
```

## Submission

The original solution file is stored in `submission/assignment/Assignment4.sln` and references the real project under `AcademyScheduleAnalyzer/`, without duplicating the source files.

`submission/leetcode/` contains `account.md` with the supplied account information, `leetcode.md` with both C# solutions and explanations, the two supplied screenshots and a README with problem links. Official copies remain in `LeetCode/images/`.

## Verification

The source and submission files were reviewed. The corrected project has not been built or run in the review environment, which lacks the .NET SDK. The supplied benchmark image records the student's existing measurements; results for 1,000 and 10,000 iterations still need to be added.
