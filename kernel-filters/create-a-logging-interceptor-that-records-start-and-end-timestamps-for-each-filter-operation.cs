// HOW-TO: Log Start and End Times for Image Filter Operations in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading;

namespace FilterLogging
{
    public interface IFilterOperation
    {
        string Name { get; }
        void Execute();
    }

    public class LoggingInterceptor
    {
        private readonly string _logPath;

        public LoggingInterceptor(string logPath)
        {
            _logPath = logPath;
        }

        public void Intercept(IFilterOperation operation)
        {
            var start = DateTime.UtcNow;
            Log($"{operation.Name} started at {start:O}");
            try
            {
                operation.Execute();
            }
            finally
            {
                var end = DateTime.UtcNow;
                Log($"{operation.Name} ended at {end:O}");
            }
        }

        private void Log(string message)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_logPath));
            File.AppendAllText(_logPath, message + Environment.NewLine);
        }
    }

    public class SampleFilter : IFilterOperation
    {
        public string Name => "SampleFilter";

        public void Execute()
        {
            Thread.Sleep(500); // Simulate work
        }
    }

    class Program
    {
        static void Main()
        {
            const string inputPath = "input.txt";
            const string outputPath = "output.log";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var interceptor = new LoggingInterceptor(outputPath);
                var filter = new SampleFilter();
                interceptor.Intercept(filter);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit the execution time of each image filter in an Aspose.Imaging processing pipeline.
 * 2. When you want to generate a simple log file that records when custom filters start and finish during batch image conversion.
 * 3. When you are troubleshooting performance bottlenecks in a C# application that applies multiple filters to large TIFF files.
 * 4. When you must comply with regulatory requirements that demand timestamped records of every image manipulation step.
 * 5. When you are building a plug‑in architecture where each filter operation should be automatically wrapped with start‑and‑end logging without modifying the filter code.
 */
