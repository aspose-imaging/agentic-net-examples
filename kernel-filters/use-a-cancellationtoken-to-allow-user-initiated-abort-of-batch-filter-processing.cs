using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Gather all PNG files from the input directory
            string[] files = Directory.GetFiles(inputDir, "*.png");

            // Cancellation token source to allow user‑initiated abort
            var cts = new CancellationTokenSource();

            // Listen for user pressing 'c' to cancel processing
            Task.Run(() =>
            {
                Console.WriteLine("Press 'c' to cancel batch processing...");
                while (Console.ReadKey(true).KeyChar != 'c')
                {
                    // ignore other keys
                }
                cts.Cancel();
            });

            // Process each image in parallel, respecting the cancellation token
            Parallel.ForEach(files, new ParallelOptions { CancellationToken = cts.Token }, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding output path (convert to BMP)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".bmp");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create an interrupt monitor for this thread
                var monitor = new InterruptMonitor();

                // If cancellation was requested before processing, interrupt immediately
                if (cts.Token.IsCancellationRequested)
                {
                    monitor.Interrupt();
                    return;
                }

                // Load the image using Aspose.Imaging
                using (Image image = Image.Load(inputPath))
                {
                    // Set the thread‑local interrupt monitor
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    try
                    {
                        // Save the image as BMP (simple conversion)
                        var saveOptions = new BmpOptions();
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

                // If a cancellation request arrives after processing, signal interruption for any remaining work
                if (cts.Token.IsCancellationRequested)
                {
                    monitor.Interrupt();
                }
            });
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Batch processing was cancelled by the user.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}