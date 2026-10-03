using System;
using System.Globalization;
using System.Text;
using BenchmarkDotNet.Running;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--benchmark")
            {
                BenchmarkRunner.Run<ReportBenchmarks>();
                return;
            }

            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations = { 180, 240, 180, 240, 180 };

            int option;
            do
            {
                Console.WriteLine("\nAcademy Schedule Analyzer");
                Console.WriteLine("1. Display all sessions");
                Console.WriteLine("2. Search for a session");
                Console.WriteLine("3. Sort session names");
                Console.WriteLine("4. Reverse session names");
                Console.WriteLine("5. Find session index");
                Console.WriteLine("6. Check if session exists");
                Console.WriteLine("7. Show duration statistics and sorted durations");
                Console.WriteLine("8. Show session date details");
                Console.WriteLine("9. Show past and upcoming sessions");
                Console.WriteLine("10. Find next session");
                Console.WriteLine("11. Compare two session dates");
                Console.WriteLine("12. Read and validate a custom date");
                Console.WriteLine("13. Select session by index");
                Console.WriteLine("14. Validate session duration");
                Console.WriteLine("15. Generate report using string");
                Console.WriteLine("16. Generate report using StringBuilder");
                Console.WriteLine("17. Find a session using a condition");
                Console.WriteLine("18. Find a session index using a condition");
                Console.WriteLine("19. Copy and change session names");
                Console.WriteLine("20. Demonstrate ref");
                Console.WriteLine("21. Find session using out");
                Console.WriteLine("22. Change an array without ref");
                Console.WriteLine("23. Demonstrate params");
                Console.WriteLine("24. Show date formats");
                Console.WriteLine("0. Exit");
                option = ReadMenuOption();

                switch (option)
                {
                    case 1:
                        DisplayAll(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 2:
                        Console.Write("Enter session name: ");
                        SearchSession(sessionNames, sessionDates, sessionDurations,
                            Console.ReadLine() ?? "");
                        break;
                    case 3:
                        SortSessionNames(sessionNames);
                        break;
                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;
                    case 5:
                        Console.Write("Enter session name: ");
                        Console.WriteLine($"Index: {Array.IndexOf(sessionNames, Console.ReadLine() ?? "")}");
                        break;
                    case 6:
                    {
                        Console.Write("Enter session name: ");
                        string search = Console.ReadLine() ?? "";
                        bool exists = Array.Exists(sessionNames, session => session == search);
                        Console.WriteLine(exists ? "Session exists." : "Session does not exist.");
                        break;
                    }
                    case 7:
                        DisplayDurationStatistics(sessionDurations);
                        break;
                    case 8:
                        Console.Write("Enter session name: ");
                        DisplaySessionDetails(sessionNames, sessionDates, sessionDurations,
                            Console.ReadLine() ?? "");
                        break;
                    case 9:
                        Compare(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 10:
                        FindNextSession(sessionNames, sessionDates);
                        break;
                    case 11:
                    {
                        Console.Write("First session: ");
                        string first = Console.ReadLine() ?? "";
                        Console.Write("Second session: ");
                        string second = Console.ReadLine() ?? "";
                        CalculateDifference(sessionNames, sessionDates, sessionDurations, first, second);
                        break;
                    }
                    case 12:
                        Console.WriteLine($"Valid date: {ReadSessionDate():yyyy-MM-dd HH:mm}");
                        break;
                    case 13:
                        ReadSessionByIndex(sessionNames);
                        break;
                    case 14:
                        Console.Write("Enter duration: ");
                        try
                        {
                            int duration = int.Parse(Console.ReadLine() ?? "");
                            ValidateDurationWithFinally(duration);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid duration. Enter a number.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Duration is outside the integer range.");
                        }
                        break;
                    case 15:
                        Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 16:
                        Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 17:
                        Console.WriteLine(Array.Find(sessionNames, session => session.Contains("Date"))
                            ?? "Session not found.");
                        break;
                    case 18:
                        Console.WriteLine($"Index: {Array.FindIndex(sessionNames, session => session.Contains("Date"))}");
                        break;
                    case 19:
                        CopySessionNames(sessionNames);
                        break;
                    case 20:
                    {
                        int duration = 50;
                        Console.WriteLine($"Before: {duration}");
                        Changeduartion(ref duration);
                        Console.WriteLine($"After: {duration}");
                        break;
                    }
                    case 21:
                    {
                        Console.Write("Enter session name: ");
                        string search = Console.ReadLine() ?? "";
                        if (FindSessionUsingOut(sessionNames, sessionDurations, search,
                            out int index, out int duration))
                        {
                            Console.WriteLine($"Index: {index}");
                            Console.WriteLine($"Duration: {duration} minutes");
                        }
                        else
                        {
                            Console.WriteLine("Session not found.");
                        }
                        break;
                    }
                    case 22:
                    {
                        int[] durations = { 120, 240, 180 };
                        Console.WriteLine($"Before: {string.Join(", ", durations)}");
                        ChangeDuration(durations);
                        Console.WriteLine($"After: {string.Join(", ", durations)}");
                        break;
                    }
                    case 23:
                        Console.WriteLine($"Total: {Totalduarion(120, 180)} minutes");
                        Console.WriteLine($"Total: {Totalduarion(120, 180, 240)} minutes");
                        Console.WriteLine($"Total: {Totalduarion(60, 90, 120, 180, 240)} minutes");
                        break;
                    case 24:
                        Console.Write("Enter session name: ");
                        DisplayDateFormats(sessionNames, sessionDates, Console.ReadLine() ?? "");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Choose an option from the menu.");
                        break;
                }
            } while (option != 0);
        }

        static void DisplayAll(string[] names, DateTime[] dates, int[] sessionDurations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
                Console.WriteLine($"Date: {dates[i].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Start Time: {dates[i].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
            }
        }

        static void SearchSession(string[] names, DateTime[] dates, int[] sessionDurations, string name)
        {
            int index = Array.IndexOf(names, name);
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
            }
            else
            {
                Console.WriteLine(names[index]);
                Console.WriteLine($"Date: {dates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Start Time: {dates[index].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
            }
        }

        static void SortSessionNames(string[] names)
        {
            string[] copiedNames = new string[names.Length];
            Array.Copy(names, copiedNames, names.Length);
            Array.Sort(copiedNames);
            foreach (string name in copiedNames)
            {
                Console.WriteLine(name);
            }
        }

        static void ReverseSessionNames(string[] names)
        {
            string[] copiedNames = new string[names.Length];
            Array.Copy(names, copiedNames, names.Length);
            Array.Reverse(copiedNames);
            foreach (string name in copiedNames)
            {
                Console.WriteLine(name);
            }
        }

        static void CopySessionNames(string[] names)
        {
            string[] copiedNames = new string[names.Length];
            Array.Copy(names, copiedNames, names.Length);
            copiedNames[0] = "Changed Session";
            Console.WriteLine("Original Array:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Copied Array:");
            foreach (string name in copiedNames)
            {
                Console.WriteLine(name);
            }
        }

        static void DisplayDurationStatistics(int[] durations)
        {
            Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
            Console.WriteLine($"Average Duration: {GetAverageDuration(durations)} minutes");
            Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
            Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");
            int[] copiedDurations = new int[durations.Length];
            Array.Copy(durations, copiedDurations, durations.Length);
            Array.Sort(copiedDurations);
            Console.WriteLine($"Sorted Durations: {string.Join(", ", copiedDurations)}");
        }

        static int GetTotalDuration(int[] durations)
        {
            int total = 0;
            for (int i = 0; i < durations.Length; i++)
            {
                total += durations[i];
            }
            return total;
        }

        static double GetAverageDuration(int[] durations)
        {
            double average = (double)GetTotalDuration(durations) / durations.Length;
            return average;
        }

        static int GetShortestDuration(int[] durations)
        {
            int shortest = durations[0];
            for (int i = 0; i < durations.Length; i++)
            {
                if (shortest > durations[i])
                {
                    shortest = durations[i];
                }
            }
            return shortest;
        }

        static int GetLongestDuration(int[] durations)
        {
            int longest = durations[0];
            for (int i = 0; i < durations.Length; i++)
            {
                if (longest < durations[i])
                {
                    longest = durations[i];
                }
            }
            return longest;
        }

        static DateTime ReadSessionDate()
        {
            while (true)
            {
                Console.Write("Enter session date (yyyy-MM-dd HH:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime sessionDate))
                {
                    return sessionDate;
                }
                Console.WriteLine("Invalid date. Use yyyy-MM-dd HH:mm.");
            }
        }

        static string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
        {
            string result = "";
            for (int i = 0; i < names.Length; i++)
            {
                result += $"{names[i]} - {dates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)} - {durations[i]} minutes" + Environment.NewLine;
            }
            return result;
        }

        static string BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                result.AppendLine($"{names[i]} - {dates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)} - {durations[i]} minutes");
            }
            return result.ToString();
        }

        static void Changeduartion(ref int duration)
        {
            duration = 500;
        }

        static void ChangeDuration(int[] durations)
        {
            durations[0] = 500;
        }

        static int Totalduarion(params int[] durations)
        {
            int total = 0;
            for (int i = 0; i < durations.Length; i++)
            {
                total += durations[i];
            }
            return total;
        }

        static bool FindSessionUsingOut(string[] names, int[] durations, string name,
            out int index, out int duration)
        {
            index = Array.IndexOf(names, name);
            duration = 0;
            if (index == -1)
            {
                return false;
            }
            duration = durations[index];
            return true;
        }

        static DateTime GetSessionEndTime(DateTime startTime, int duration)
        {
            return startTime.AddMinutes(duration);
        }

        static void DisplaySessionDetails(string[] names, DateTime[] dates, int[] durations, string search)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == search)
                {
                    Console.WriteLine($"Session: {names[i]}");
                    Console.WriteLine($"Full Date: {dates[i].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"Day of Week: {dates[i].DayOfWeek}");
                    Console.WriteLine($"Year: {dates[i].Year}");
                    Console.WriteLine($"Month: {dates[i].Month}");
                    Console.WriteLine($"Day: {dates[i].Day}");
                    Console.WriteLine($"Start Time: {dates[i].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"Duration: {durations[i]} minutes");
                    Console.WriteLine($"End Time: {GetSessionEndTime(dates[i], durations[i]).ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                    return;
                }
            }
            Console.WriteLine("Session not found.");
        }

        static void CalculateDifference(string[] names, DateTime[] dates, int[] durations, string n, string t)
        {
            int firstIndex = Array.IndexOf(names, n);
            int endIndex = Array.IndexOf(names, t);
            if (firstIndex == -1 || endIndex == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }
            TimeSpan difference = dates[endIndex] - dates[firstIndex];
            Console.WriteLine($"Total Days: {difference.TotalDays}");
            Console.WriteLine($"Total Hours: {difference.TotalHours}");
        }

        static void Compare(string[] names, DateTime[] dates, int[] durations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (dates[i] < DateTime.Now)
                {
                    Console.WriteLine($"{names[i]}: Past");
                }
                else
                {
                    Console.WriteLine($"{names[i]}: Upcoming");
                }
            }
        }

        static void FindNextSession(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            int nextIndex = -1;
            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] > now && (nextIndex == -1 || dates[i] < dates[nextIndex]))
                {
                    nextIndex = i;
                }
            }
            if (nextIndex == -1)
            {
                Console.WriteLine("No upcoming sessions.");
                return;
            }
            TimeSpan remaining = dates[nextIndex] - now;
            Console.WriteLine($"Next Session: {names[nextIndex]}");
            Console.WriteLine($"Date: {dates[nextIndex].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Start Time: {dates[nextIndex].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Remaining days: {remaining.Days}");
            Console.WriteLine($"Remaining hours: {remaining.Hours}");
        }

        static void DisplayDateFormats(string[] names, DateTime[] dates, string sessionName)
        {
            int index = Array.IndexOf(names, sessionName);
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }
            Console.WriteLine(dates[index].ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            Console.WriteLine(dates[index].ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(dates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(dates[index].ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(dates[index].ToString("hh:mm tt", CultureInfo.InvariantCulture));
        }

        static int ReadMenuOption()
        {
            while (true)
            {
                try
                {
                    Console.Write("Choose an option: ");
                    int option = int.Parse(Console.ReadLine() ?? "");
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Menu option is outside the integer range.");
                }
            }
        }

        static void ReadSessionByIndex(string[] names)
        {
            try
            {
                Console.Write("Enter session index: ");
                int index = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine($"Session: {names[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid index. Enter a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Index is outside the integer range.");
            }
        }

        static void ValidateDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            Console.WriteLine("Duration accepted.");
        }

        static void ValidateDurationWithFinally(int duration)
        {
            try
            {
                ValidateDuration(duration);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }
    }
}
