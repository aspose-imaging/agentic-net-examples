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
            // Hardcoded input and output paths
            string[] inputPaths = {
                @"C:\Images\image1.png",
                @"C:\Images\image2.png"
            };

            string[] outputPaths = {
                @"C:\Output\image1.bmp",
                @"C:\Output\image2.bmp"
            };

            // Cancellation token source for user‑initiated abort
            var cts = new CancellationTokenSource();

            // Task that waits for user to press 'c' to cancel processing
            Task.Run(() =>
            {
                Console.WriteLine("Press 'c' to cancel processing...");
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == 'c' || key.KeyChar == 'C')
                    {
                        cts.Cancel();
                        Console.WriteLine("Cancellation requested.");
                        break;
                    }
                }
            });

            // Process each image in the batch
            for (int i = 0; i < inputPaths.Length; i++)
            {
                // Abort if cancellation was requested
                if (cts.Token.IsCancellationRequested)
                    break;

                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up an interrupt monitor for this thread
                    var monitor = new InterruptMonitor();
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    // If cancellation was requested just before saving, interrupt the operation
                    if (cts.Token.IsCancellationRequested)
                    {
                        monitor.Interrupt();
                        break;
                    }

                    // Define save options (e.g., BMP format)
                    var saveOptions = new BmpOptions();

                    try
                    {
                        // Save the processed image
                        image.Save(outputPath, saveOptions);
                    }
                    catch (OperationInterruptedException)
                    {
                        Console.WriteLine($"Processing of {inputPath} was interrupted.");
                    }
                    finally
                    {
                        // Reset the thread‑local interrupt monitor
                        InterruptMonitor.ThreadLocalInstance = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}