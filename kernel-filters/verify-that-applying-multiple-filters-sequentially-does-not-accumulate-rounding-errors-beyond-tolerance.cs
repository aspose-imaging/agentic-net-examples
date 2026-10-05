// HOW-TO: Verify No Accumulated Rounding Errors When Applying Sequential Filters in C# (Aspose.Imaging for .NET)
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RoundingErrorVerification
{
    interface IFilter
    {
        double Apply(double value);
    }

    class AddFilter : IFilter
    {
        private readonly double _addend;
        private readonly int _precision;

        public AddFilter(double addend, int precision)
        {
            _addend = addend;
            _precision = precision;
        }

        public double Apply(double value)
        {
            double result = value + _addend;
            return Math.Round(result, _precision, MidpointRounding.AwayFromZero);
        }
    }

    class MultiplyFilter : IFilter
    {
        private readonly double _factor;
        private readonly int _precision;

        public MultiplyFilter(double factor, int precision)
        {
            _factor = factor;
            _precision = precision;
        }

        public double Apply(double value)
        {
            double result = value * _factor;
            return Math.Round(result, _precision, MidpointRounding.AwayFromZero);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "input.txt";
                string outputPath = "output.txt";

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Read input numbers (one per line)
                var lines = File.ReadAllLines(inputPath);
                var numbers = new List<double>();
                foreach (var line in lines)
                {
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        numbers.Add(val);
                    }
                }

                // Define filters
                var filters = new List<IFilter>
                {
                    new AddFilter(0.1, 2),          // add 0.1, round to 2 decimals
                    new MultiplyFilter(1.05, 2),   // multiply by 1.05, round to 2 decimals
                    new AddFilter(-0.05, 2)        // subtract 0.05, round to 2 decimals
                };

                // Apply filters sequentially
                var sequentialResults = numbers.Select(v =>
                {
                    double temp = v;
                    foreach (var f in filters)
                    {
                        temp = f.Apply(temp);
                    }
                    return temp;
                }).ToList();

                // Compute combined effect analytically (without intermediate rounding)
                double combinedAdd = 0.1 - 0.05; // net addition before multiplication
                double combinedFactor = 1.05;
                var combinedResults = numbers.Select(v =>
                {
                    double temp = v + combinedAdd;
                    temp *= combinedFactor;
                    return Math.Round(temp, 2, MidpointRounding.AwayFromZero);
                }).ToList();

                // Compare differences
                double maxDifference = 0.0;
                for (int i = 0; i < sequentialResults.Count; i++)
                {
                    double diff = Math.Abs(sequentialResults[i] - combinedResults[i]);
                    if (diff > maxDifference) maxDifference = diff;
                }

                double tolerance = 0.01;
                bool withinTolerance = maxDifference <= tolerance;

                // Write results
                var outputLines = new List<string>
                {
                    $"Max difference: {maxDifference.ToString(CultureInfo.InvariantCulture)}",
                    $"Within tolerance ({tolerance}): {withinTolerance}"
                };
                File.WriteAllLines(outputPath, outputLines);
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
 * 1. When a developer needs to ensure that applying brightness and contrast adjustments to pixel values in a batch image processing job does not introduce cumulative rounding errors.
 * 2. When validating that a series of financial calculations performed on CSV data, such as adding fees and applying tax multipliers, remain within a defined tolerance after each rounding step.
 * 3. When building a scientific data pipeline that reads measurement values from a text file, applies calibration offsets and scaling factors, and must guarantee precision is preserved.
 * 4. When creating a custom image filter chain in Aspose.Imaging that sequentially adds a constant to each channel and then multiplies by a factor, and you need to confirm the final pixel values are accurate.
 * 5. When automating image metadata transformation where numeric tags are incremented and scaled, and you must verify that rounding after each operation does not drift beyond acceptable limits.
 */
