using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;

class Program
{
    // Hard‑coded input and output directories
    private const string InputDirectory = @"C:\temp\webp";
    private const string OutputDirectory = @"C:\temp\gif";

    static async Task Main()
    {
        try
        {
            // Verify input directory exists
            if (!Directory.Exists(InputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {InputDirectory}");
                return;
            }

            // Ensure output directory exists (CreateDirectory handles null safely)
            Directory.CreateDirectory(OutputDirectory);

            // Gather all WebP files in the input directory
            var inputFiles = Directory.GetFiles(InputDirectory, "*.webp");
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No WebP files found to process.");
                return;
            }

            // Cancellation token source – press any key to cancel
            using var cts = new CancellationTokenSource();

            // Start a task that waits for a key press and then cancels
            Task.Run(() =>
            {
                Console.WriteLine("Press any key to cancel the batch conversion...");
                Console.ReadKey(intercept: true);
                cts.Cancel();
            });

            // Process files asynchronously, respecting the cancellation token
            await ProcessFilesAsync(inputFiles, cts.Token);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ProcessFilesAsync(string[] files, CancellationToken token)
    {
        // Process each file sequentially; you could run them in parallel with Task.WhenAll if desired
        foreach (var inputPath in files)
        {
            // Respect cancellation request
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested. Stopping processing.");
                break;
            }

            // Input file existence check (rule 2)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output path (same file name with .gif extension)
            var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
            var outputPath = Path.Combine(OutputDirectory, outputFileName);

            // Ensure output directory exists (rule 3)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load WebP image (using the provided constructor rule)
                using var webPImage = new WebPImage(inputPath);

                // Prepare GIF save options
                var gifOptions = new GifOptions();

                // Save as GIF (asynchronous wrapper)
                await Task.Run(() =>
                {
                    // Set up interrupt monitor to allow graceful cancellation inside Aspose.Imaging
                    var monitor = new InterruptMonitor();
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    try
                    {
                        // If cancellation is requested, signal interruption
                        if (token.IsCancellationRequested)
                        {
                            monitor.Interrupt();
                        }

                        webPImage.Save(outputPath, gifOptions);
                    }
                    finally
                    {
                        // Reset thread‑local monitor
                        InterruptMonitor.ThreadLocalInstance = null;
                    }
                }, token);

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled by user.");
                break;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to convert {inputPath}: {ex.Message}");
            }
        }
    }
}