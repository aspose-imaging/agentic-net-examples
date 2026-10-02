// HOW-TO: Filter Text File for Important Lines Using C# LINQ (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;

namespace FilterExample
{
    /// <summary>
    /// Demonstrates how to apply a simple filter to a collection of strings read from a file.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        private static void Main()
        {
            // Hard‑coded input and output file locations.
            const string inputPath = "input.txt";
            const string outputPath = "output.txt";

            try
            {
                // Verify that the input file exists before attempting to read it.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists; CreateDirectory is safe to call even if the directory already exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Read all lines from the input file.
                // Using File.ReadAllLines reads the entire file into memory; suitable for small to medium files.
                string[] allLines = File.ReadAllLines(inputPath);

                // Define the filter criteria.
                // In this example we keep only lines that contain the word "important" (case‑insensitive).
                // The filter is expressed as a LINQ Where clause, which lazily evaluates the predicate.
                var filteredLines = allLines
                    .Where(line => line.IndexOf("important", StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToArray();

                // Write the filtered lines to the output file.
                // File.WriteAllLines overwrites any existing file at the specified path.
                File.WriteAllLines(outputPath, filteredLines);
            }
            catch (Exception ex)
            {
                // Any unexpected exception is caught and reported without crashing the process.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract only the log entries that contain the keyword "important" from a large .txt diagnostic file before further analysis.
 * 2. When a batch job must remove non‑essential lines from a configuration file so that only critical settings are retained for deployment.
 * 3. When a data‑import routine has to pre‑filter a CSV‑style text file for rows that include a specific tag, using LINQ and case‑insensitive matching in C#.
 * 4. When an automated report generator should write only the relevant sections of a markdown document that mention "important" to a separate output file.
 * 5. When a migration script must read a list of file paths, keep only those marked as "important", and save the filtered list for subsequent processing.
 */
