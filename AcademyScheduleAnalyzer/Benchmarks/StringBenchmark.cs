using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Assignment4
{
    [MemoryDiagnoser]
    [SimpleJob(warmupCount: 1, iterationCount: 3)]
    public class ReportBenchmarks
    {
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;

        private const string Text = "C# Basics - 10/09/2026 06:00 PM - 180 minutes";

        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";

            for (int i = 0; i < Iterations; i++)
            {
                result += Text;
            }

            return result;
        }

        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Iterations; i++)
            {
                result.Append(Text);
            }

            return result.ToString();
        }
    }
}