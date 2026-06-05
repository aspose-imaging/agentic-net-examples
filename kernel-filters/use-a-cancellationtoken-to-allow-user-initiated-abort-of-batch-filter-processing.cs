using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.Multithreading;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new[]
        {
            @"c:\temp\input1.png",
            @"c:\temp\input2.png"
        };

        string[] outputPaths = new[]
        {
            @"c:\temp\output1.bmp",
            @"c:\temp\output2.bmp"
        };

        // Ensure input and output arrays have the same length
        if (inputPaths.Length != outputPaths.Length)
        {
            Console.Error.WriteLine("Mismatched input/output count.");
            return;
        }

        // Cancellation support
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        // Interrupt monitor used by Aspose.Imaging to stop operations
        var monitor = new InterruptMonitor();

        // Optional: allow user to press any key to cancel processing
        Task.Run(() =>
        {
            Console.WriteLine("Press any key to abort processing...");
            Console.ReadKey(true);
            cts.Cancel();
        });

        try
        {
            // Process each image in a separate task to respect the cancellation token
            Parallel.For(0, inputPaths.Length, new ParallelOptions { CancellationToken = token }, index =>
            {
                string inputPath = inputPaths[index];
                string outputPath = outputPaths[index];

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // If cancellation requested before starting, interrupt and exit
                if (token.IsCancellationRequested)
                {
                    monitor.Interrupt();
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set thread‑local interrupt monitor so Aspose.Imaging can observe interruptions
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    try
                    {
                        // Example filter: convert to BMP using BmpOptions
                        var saveOptions = new BmpOptions();

                        // Save the processed image
                        image.Save(outputPath, saveOptions);
                    }
                    catch (Aspose.Imaging.CoreExceptions.OperationInterruptedException)
                    {
                        Console.WriteLine($"Processing of {inputPath} was interrupted.");
                    }
                    finally
                    {
                        // Reset the thread‑local monitor
                        InterruptMonitor.ThreadLocalInstance = null;
                    }
                }
            });
        }
        catch (OperationCanceledException)
        {
            // Propagate cancellation to Aspose.Imaging
            monitor.Interrupt();
            Console.WriteLine("Batch processing was cancelled by the user.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application lets users convert a batch of PNG screenshots to BMP format and they need to stop the operation if they change their mind.
 * 2. When a server‑side service processes uploaded product images in parallel and must abort the job if the client disconnects or a timeout occurs.
 * 3. When an automated nightly build script applies filters to thousands of design assets and should cancel the run if a critical error is detected elsewhere in the pipeline.
 * 4. When a Windows service monitors a folder for new images and applies transformations, allowing an administrator to press a key to halt processing during maintenance.
 * 5. When a cloud function processes user‑provided images and respects a cancellation token passed from an upstream API request to avoid unnecessary compute charges.
 */