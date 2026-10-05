// HOW-TO: Cancel Batch Text File Processing With CancellationToken In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BatchFilterApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputPath = "data\\input.txt";
                string outputPath = "data\\output.txt";

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up cancellation
                var cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;

                // Start a task to listen for user abort (press 'c')
                Task.Run(() =>
                {
                    Console.WriteLine("Press 'c' to cancel processing...");
                    while (true)
                    {
                        var keyInfo = Console.ReadKey(true);
                        if (keyInfo.KeyChar == 'c' || keyInfo.KeyChar == 'C')
                        {
                            cts.Cancel();
                            break;
                        }
                    }
                });

                // Begin batch processing
                using (var reader = new StreamReader(inputPath))
                using (var writer = new StreamWriter(outputPath, false))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Check for cancellation request
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Processing cancelled by user.");
                            break;
                        }

                        // Simulate filter processing (e.g., convert to upper case)
                        string processedLine = ApplyFilter(line);

                        writer.WriteLine(processedLine);
                    }
                }

                if (!token.IsCancellationRequested)
                {
                    Console.WriteLine("Batch processing completed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static string ApplyFilter(string input)
        {
            // Placeholder for actual filter logic
            return input.ToUpperInvariant();
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to process a large list of image files in a console app and wants the user to be able to abort the batch operation by pressing a key.
 * 2. When building a bulk image conversion tool that applies Aspose.Imaging filters to many files and requires a responsive cancel option during long‑running processing.
 * 3. When importing thousands of records from a CSV or text file into a database and the operation must be stoppable without terminating the whole application.
 * 4. When creating a script that reads image paths from a text file, performs downloads or transformations, and should stop immediately if the operator requests cancellation.
 * 5. When designing a scheduled service that runs nightly image processing jobs and you need to expose a cancellation token so an administrator can cancel the current run from the command line.
 */
