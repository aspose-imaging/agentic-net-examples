// HOW-TO: Cancel Batch Image Filter Processing With CancellationToken In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input files
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.jpg",
                @"C:\Images\input2.png"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Processed";

            // Cancellation token source for user‑initiated abort
            var cts = new CancellationTokenSource();

            // Background task that watches for the user to press 'q' to cancel
            Task.Run(() =>
            {
                Console.WriteLine("Press 'q' to cancel processing...");
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                    {
                        cts.Cancel();
                        break;
                    }
                }
            });

            // Single interrupt monitor shared across the batch
            var monitor = new InterruptMonitor();

            foreach (var inputPath in inputPaths)
            {
                // Stop processing if cancellation was requested
                if (cts.IsCancellationRequested)
                    break;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build output path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_processed.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set thread‑local interrupt monitor so Aspose can react to interruption
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    try
                    {
                        // Check for cancellation before the save operation
                        if (cts.IsCancellationRequested)
                        {
                            monitor.Interrupt();
                        }

                        // Save the image using BMP options (example filter could be added here)
                        var bmpOptions = new BmpOptions();
                        image.Save(outputPath, bmpOptions);

                        Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
                    }
                    catch (OperationInterruptedException)
                    {
                        Console.WriteLine($"Processing of {inputPath} was interrupted.");
                    }
                    finally
                    {
                        // Reset the thread‑local monitor
                        InterruptMonitor.ThreadLocalInstance = null;
                    }
                }
            }

            Console.WriteLine("Batch processing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop utility needs to apply the same Aspose.Imaging filter to dozens of JPEG and PNG files but must let the user stop the operation instantly by pressing a key.
 * 2. When an automated image‑processing pipeline runs as a background task and you want to provide a graceful shutdown mechanism using a CancellationToken to avoid partially processed files.
 * 3. When you are building a command‑line tool that converts images to BMP format and you need to monitor for user‑initiated cancellation to prevent unnecessary CPU usage.
 * 4. When processing a batch of high‑resolution images in parallel with Aspose.Imaging’s InterruptMonitor and you must ensure the operation can be aborted without corrupting the output directory.
 * 5. When integrating Aspose.Imaging into a Windows service that handles image transformations and you require a way to cancel the batch job on demand to maintain service responsiveness.
 */
