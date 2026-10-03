# Academy Schedule Analyzer

**Assignment 4 — C# Fundamentals**

Explore how a training academy can review its sessions, calculate training hours, track dates and prepare schedule reports through a simple console application.

This guide explains the program step by step for C# beginners, connecting each feature to the arrays, functions, date calculations and exception handling used in the code.

## What does it do for an academy?

Imagine an academy running a short C# course. Its coordinator needs to answer questions such as: Which sessions are planned? When does a session start and finish? How many training minutes does the course contain? Which sessions have already passed? What is the next session?

The application answers these questions using a small sample schedule.

| Academy task | What the application provides |
| --- | --- |
| Review the training plan | Displays every session with its name, date, start time and duration. |
| Look up a particular session | Searches by name and displays its details. |
| Understand the course workload | Calculates total, average, shortest and longest durations. |
| Plan around session times | Calculates end times and differences between session dates. |
| Follow the schedule | Labels sessions as past/upcoming and finds the nearest future session. |
| Prepare a schedule summary | Generates the same text report using two different C# techniques. |
| Handle input mistakes | Displays messages for invalid numbers, dates, indexes and durations. |

This is a console learning prototype with five sessions stored in memory. The schedule is initialized each time the program starts. The date-entry operation validates and displays a date; it does not add a new session. Copying and parameter-passing examples demonstrate language behavior using separate data, so they do not replace the original academy schedule.

## Who is this assignment for?

This project is for learners who know basic C# variables and want to understand how several concepts work together in one application. The main program uses arrays and functions rather than custom `Session`, `Course` or `Student` classes. There is no LINQ in the application source. The additional `ReportBenchmarks` class exists for BenchmarkDotNet.

By working through the project, you practice:

- Representing related data with arrays and accessing it by index.
- Using `for`, `foreach`, `while`, `do-while`, `if` and `switch`.
- Writing functions with parameters and different return types.
- Understanding `ref`, `out`, `params` and reference-type parameters.
- Calculating and formatting dates and time intervals.
- Validating input and handling specific exceptions.
- Building text with `string` and `StringBuilder`.
- Comparing execution time and allocated memory with BenchmarkDotNet.

## How the schedule is stored

The application has three parallel arrays:

| Array | C# type | Stored information |
| --- | --- | --- |
| `sessionNames` | `string[]` | Session names. |
| `sessionDates` | `DateTime[]` | Each session's date and starting time. |
| `sessionDurations` | `int[]` | Each session's duration in minutes. |

**The same index in all three arrays describes one session.** C# array indexes start at zero, so index `1` means the second session.

```csharp
sessionNames[1]      // "Arrays"
sessionDates[1]      // 13 September 2026 at 18:00
sessionDurations[1]  // 240 minutes
```

The starter schedule is:

| Index | Session | Date | Start time | Duration |
| ---: | --- | --- | --- | ---: |
| 0 | C# Basics | 10 September 2026 | 06:00 PM | 180 minutes |
| 1 | Arrays | 13 September 2026 | 06:00 PM | 240 minutes |
| 2 | Functions | 17 September 2026 | 06:00 PM | 180 minutes |
| 3 | Date and Time | 20 September 2026 | 06:00 PM | 240 minutes |
| 4 | Exception Handling | 24 September 2026 | 06:00 PM | 180 minutes |

Keeping these arrays aligned matters. Sorting only the original names would break the relationship between a name, its date and its duration. The sort and reverse operations therefore work on copies of the names array.

## How to download and run it

The project targets **.NET 9** and references **BenchmarkDotNet 0.15.8**. Use a .NET 9 SDK and restore the NuGet dependency before building.

### Get the assignment branch

```bash
git clone --branch assignment/1-4 https://github.com/Mohamed-Ahmed984/Mohamed-Ahmed984-Assignment-4.git
cd Mohamed-Ahmed984-Assignment-4
```

If downloading a ZIP instead, select the assignment branch on GitHub and extract the entire archive. Keep the folder structure together.

### Run from a terminal

Run these commands from the repository root:

```bash
dotnet restore submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj
dotnet build submission/assignment/Assignment4.sln -c Release
dotnet run --project submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj
```

### Open in Visual Studio

1. Download or clone the complete repository.
2. Open `submission/assignment/Assignment4.sln`, or open `submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj` directly.
3. Open `Program.cs` in Solution Explorer to read the application code.
4. Run the console application.

The solution refers to `AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj` inside the same assignment folder. Extract the files before opening the solution, and keep the contents of `submission/assignment/` together.

## Using the console menu

Enter an option number and follow its prompts. The menu appears again after each operation until you choose `0`.

For name-based operations, enter the exact starter name, such as `Arrays` or `C# Basics`. Searches are case-sensitive and do not trim surrounding spaces. Index-based operations use indexes `0` through `4`.

| Option | Operation | What to expect |
| ---: | --- | --- |
| 0 | Exit | Ends the application. |
| 1 | Display all sessions | Shows names, dates, start times and durations. |
| 2 | Search for a session | Enter a name; displays its details or a not-found message. |
| 3 | Sort session names | Displays an alphabetically sorted copy. |
| 4 | Reverse session names | Displays a reversed copy. |
| 5 | Find session index | Displays the zero-based index, or `-1` when absent. |
| 6 | Check if a session exists | Displays an existence message. |
| 7 | Show duration statistics | Displays total, average, shortest, longest and a sorted duration copy. |
| 8 | Show session date details | Displays date components, duration and calculated end time. |
| 9 | Show past/upcoming sessions | Compares each start date/time with `DateTime.Now`. |
| 10 | Find next session | Finds the nearest future start time and time remaining. |
| 11 | Compare two session dates | Calculates the second date minus the first. |
| 12 | Validate a custom date | Repeats until the exact required date format is valid. |
| 13 | Select by index | Accesses the array and handles an out-of-range index. |
| 14 | Validate duration | Accepts positive durations and handles zero/negative values. |
| 15 | Generate a string report | Builds the schedule text with repeated concatenation. |
| 16 | Generate a StringBuilder report | Builds equivalent schedule text with `AppendLine`. |
| 17 | Find using a condition | Finds the first name containing `Date`. |
| 18 | Find an index using a condition | Finds the index of the first name containing `Date`. |
| 19 | Copy and change names | Shows that changing a copied array leaves the original unchanged. |
| 20 | Demonstrate ref | Changes an integer from 50 to 500 and displays before/after values. |
| 21 | Demonstrate out | Searches by name and returns both index and duration. |
| 22 | Change an array without ref | Changes the first element of a separate demonstration array. |
| 23 | Demonstrate params | Calculates totals using different numbers of arguments. |
| 24 | Show date formats | Displays one selected date/time in five formats. |

## Understanding the C# implementation

### Functions divide the work

`Main` creates the starter data, displays the menu and dispatches the selected operation using `switch`. Functions below it perform the individual tasks.

| Function | Responsibility | Return type |
| --- | --- | --- |
| `DisplayAll` | Display the schedule arrays together. | `void` |
| `SearchSession` | Find a name and display the matching session. | `void` |
| `GetTotalDuration` | Add every duration. | `int` |
| `GetAverageDuration` | Divide the total by the number of sessions. | `double` |
| `GetShortestDuration` / `GetLongestDuration` | Find the smallest/largest duration. | `int` |
| `GetSessionEndTime` | Add a duration to a starting time. | `DateTime` |
| `ReadSessionDate` | Read a valid date using the required format. | `DateTime` |
| `FindSessionUsingOut` | Indicate whether a search succeeded and return two additional values. | `bool` |
| `BuildReportUsingString` / `BuildReportUsingStringBuilder` | Return complete report text. | `string` |

`void` means the function returns no value to its caller. A function returning `int`, `double`, `DateTime` or `string` gives the caller a value it can display or use in another calculation.

### Array methods each have a different role

| Method | Meaning in this assignment |
| --- | --- |
| `Array.IndexOf` | Find the index of an exact name. |
| `Array.Exists` | Check whether at least one name matches a condition. |
| `Array.Find` | Return the first name matching a condition. |
| `Array.FindIndex` | Return the first matching index. |
| `Array.Copy` | Copy values into another array. |
| `Array.Sort` | Put a copied array in ascending order. |
| `Array.Reverse` | Reverse the order of a copied array. |

In `session => session.Contains("Date")`, the part after `=>` is the condition tested for each name. It matches `Date and Time` in the starter data. A missing index is `-1`; a missing string from `Array.Find` is handled with a not-found message.

### Duration analysis uses actual data

The total function starts at zero and adds each array element:

```csharp
int total = 0;
for (int i = 0; i < durations.Length; i++)
{
    total += durations[i];
}
```

The shortest and longest functions begin with the first element, then compare it with the other elements. These functions are called with the nonempty starter array.

The average uses `(double)GetTotalDuration(durations) / durations.Length`. Converting the total to `double` prevents integer division from discarding a fractional result.

For the starter data, the calculated results are:

| Calculation | Result |
| --- | ---: |
| Total | 1,020 minutes |
| Average | 204 minutes |
| Shortest | 180 minutes |
| Longest | 240 minutes |

These are example results derived from the five durations; the source calculates them rather than hard-coding the answers.

### DateTime represents a point in time; TimeSpan represents a duration

The `Arrays` session begins at 06:00 PM and lasts 240 minutes. `AddMinutes(240)` calculates its end time as 10:00 PM.

Subtracting the date of `C# Basics` from the date of `Arrays` produces a `TimeSpan` of 3 days, or 72 hours. The comparison operation displays `TotalDays` and `TotalHours`. Reversing the input order produces a negative difference because the calculation is second date minus first date.

The next-session search ignores dates that are not later than the computer's current local date/time, then keeps the nearest future candidate. Its remaining-time display uses whole days plus the remaining hour component.

**The starter dates are fixed in September 2026.** When running after the final session's start time, all starter sessions are past and option 10 correctly displays `No upcoming sessions.`

Date input must use `yyyy-MM-dd HH:mm`, for example:

```text
2026-10-15 18:30
```

`TryParseExact` checks both the format and valid date/time values. Inputs such as `hello`, `15/10/2026`, or `2026-10-15 30:00` are rejected and the function asks again.

### ref, out and params solve different problems

| Concept | What the example demonstrates |
| --- | --- |
| `ref int` | The function can change the caller's integer variable. The variable already has a value before the call. |
| `out` | The search returns an index and duration in addition to its `bool` result. The function assigns both output values before returning. |
| `params int[]` | One function accepts different numbers of duration arguments and adds them. |
| Array parameter without `ref` | The function can change an element of the array object the caller also references. |

For example, `Totalduarion(120, 180)` returns 300, while `Totalduarion(120, 180, 240)` returns 540.

An array is a reference type. Passing it normally copies the reference, so the caller and function can still refer to the same array object. Changing an element affects that shared object. Reassigning the parameter to a different array would only change the function's local reference unless the parameter were passed with `ref`.

### Input validation and exceptions

| Input problem | How it is handled |
| --- | --- |
| Menu input such as `hello` | `int.Parse` throws `FormatException`; the function catches it and asks again. |
| An integer outside the supported range | A specific `OverflowException` catch displays a message. |
| Session index such as `50` | Array access throws `IndexOutOfRangeException`; the operation catches it. |
| Duration of `0` or `-20` | The validator deliberately throws `ArgumentException`; its caller displays the message. |
| Invalid date text | `TryParseExact` returns false, allowing an ordinary retry without using exceptions for expected invalid dates. |

When the duration-validation wrapper runs, its `finally` block prints `Input operation finished.` whether the numeric duration is accepted or rejected. Non-numeric duration input is handled by a separate parsing catch before that wrapper is called.

### string and StringBuilder produce the same academy report

Both report functions include each session's name, formatted date/start time and duration. A report line looks like:

```text
C# Basics - 10/09/2026 06:00 PM - 180 minutes
```

The `string` version uses `+=` inside a loop. Strings are immutable, so repeated concatenation generally creates new strings and copies previous content. The `StringBuilder` version appends into mutable buffers and calls `ToString()` to create the final string.

The intended text and line endings are equivalent. The difference is how the text is built, which the benchmark explores separately.

## Performance experiment with BenchmarkDotNet

Run the benchmark separately from the interactive menu:

```bash
dotnet run --project submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj -c Release -- --benchmark
```

Each benchmark method appends the **same text** repeatedly and returns the result. The measured loops do not print to the console. This experiment repeats one line to study text-building performance; it does not repeatedly display the academy menu.

| Configuration | Meaning |
| --- | --- |
| `[Params(100, 1000, 10000, 100000)]` | Run each approach with four different numbers of appends. |
| `[Benchmark]` | Mark a method for measurement. |
| `[MemoryDiagnoser]` | Include managed-memory allocation information. |
| `[SimpleJob(warmupCount: 1, iterationCount: 3)]` | Configure one warmup iteration and three measurement iterations for each case. |

The appends parameter is different from BenchmarkDotNet's measurement iteration count. BenchmarkDotNet can invoke a method multiple times during a measurement iteration; three measurement iterations do not mean exactly three appends or exactly three total method calls.

The results report mean execution time, error, standard deviation and allocated memory. Allocated memory is cumulative allocation per operation, not the final string size or peak memory held at one moment.

See [BENCHMARK.md](submission/assignment/BENCHMARK.md) for the supplied result table and all seven analysis answers. The supplied run contains results for 100 and 100,000 appends. The source is configured for all four required sizes; results for 1,000 and 10,000 still need to be produced. At the largest size, repeated string concatenation can take a long time.

StringBuilder is useful for repeated appends, but it is not automatically the best choice for every small string operation. Conclusions should follow the actual workload and measurements.

### Original benchmark output

![BenchmarkDotNet output comparing string concatenation with StringBuilder](submission/assignment/benchmark-results.png)

This is the student's supplied output for 100 and 100,000 appends. In both displayed cases, StringBuilder has a lower mean execution time and allocates less memory. The image uses the original names `N` and `StringBuilderReport`; the current source names are `Iterations` and `StringBuilderConcatenation`. The two intermediate sizes are not shown in this run.

## Separate LeetCode practice

The assignment also includes two independent problem-solving exercises:

| Problem | Main idea in the documented solution |
| --- | --- |
| [Valid Anagram](https://leetcode.com/problems/valid-anagram/) | Compare lengths, sort character arrays, then compare characters with a loop. |
| [Greatest Common Divisor of Strings](https://leetcode.com/problems/greatest-common-divisor-of-strings/) | Check repeating-pattern compatibility, find the GCD of the lengths, then return the corresponding prefix. |

[leetcode.md](submission/leetcode/leetcode.md) contains both C# solutions, explanations, complexities and screenshot references. These code blocks are separate from the console application.

[Evidence overview](submission/leetcode/README.md)

The supplied screenshots show Accepted under Test Result. Full Submit acceptance and acceptance of the documented revised code have not been independently verified.

## Repository and submission files

| Path | Purpose |
| --- | --- |
| [submission/assignment/AcademyScheduleAnalyzer/Program.cs](submission/assignment/AcademyScheduleAnalyzer/Program.cs) | Menu, starter arrays and application functions. |
| [submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj](submission/assignment/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj) | .NET target and package reference. |
| [submission/assignment/AcademyScheduleAnalyzer/Benchmarks/StringBenchmark.cs](submission/assignment/AcademyScheduleAnalyzer/Benchmarks/StringBenchmark.cs) | BenchmarkDotNet experiment. |
| [submission/assignment/Assignment4.sln](submission/assignment/Assignment4.sln) | Real solution file referring to the application project. |
| [submission/leetcode/account.md](submission/leetcode/account.md) | Actual supplied LeetCode account information. |
| [submission/leetcode/leetcode.md](submission/leetcode/leetcode.md) | Independent solutions and learning explanations. |
| `submission/leetcode/` | Supplied screenshots and submission README. |
| `submission/leetcode/images/` | Original supplied LeetCode screenshots. |
| [BENCHMARK.md](submission/assignment/BENCHMARK.md) | Existing measurements and performance analysis. |

All application source, project and solution files, benchmark analysis and benchmark screenshot are grouped inside `submission/assignment/`. All LeetCode documents and screenshots are grouped inside `submission/leetcode/`, with one copy of each screenshot in `images/`. You can copy the complete `submission/assignment/` folder without breaking the solution's project reference.

## Suggested learning walkthrough

1. Run option 1 and identify how the same array index supplies all details for one session.
2. Search for `Arrays` with option 2, then try a missing name to understand the `-1` result.
3. Use options 3, 4 and 19, then display the original schedule again to observe why copies matter.
4. Read the duration functions and check the calculated results with option 7.
5. Try options 8, 11 and 24 to distinguish date values, formatting and time intervals.
6. Use option 12 with valid and invalid text to understand exact date parsing.
7. Try menu input `hello`, index `50`, and duration `-20` to follow the different error-handling paths.
8. Compare options 20–23 while reading the parameter-passing functions.
9. Compare the reports from options 15 and 16 before inspecting the separate benchmark.
10. Study the independent LeetCode solutions and explain their reasoning and complexity in your own words.

## Verification status

The source structure, submission files and local links have been checked. The corrected console application and updated benchmark have not been built or executed in the preparation environment because it lacks the .NET SDK. The existing benchmark screenshot records the student's supplied measurements. Results for the two intermediate sizes and full accepted LeetCode Submit evidence remain to be verified.
