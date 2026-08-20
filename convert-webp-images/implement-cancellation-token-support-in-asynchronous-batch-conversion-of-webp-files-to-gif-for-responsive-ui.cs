// HOW-TO: Asynchronously Convert Multiple WebP Files to GIF with Cancellation in C# (Aspose.Imaging for .NET)
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
    // Hardcoded input and output directories
    private const string InputDirectory = @"C:\temp\input\";
    private const string OutputDirectory = @"C:\temp\output\";

    static async Task Main()
    {
        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(OutputDirectory);

            // Create a cancellation token source that can be triggered by user input
            using var cts = new CancellationTokenSource();

            // Start a task that waits for the user to press 'c' to cancel
            Task.Run(() =>
            {
                Console.WriteLine("Press 'c' to cancel the batch conversion...");
                while (Console.ReadKey(true).KeyChar != 'c')
                {
                    // ignore other keys
                }
                cts.Cancel();
                Console.WriteLine("Cancellation requested.");
            });

            // Gather all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(InputDirectory, "*.webp");

            // Create a list of conversion tasks
            var conversionTasks = webpFiles.Select(inputPath =>
            {
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(OutputDirectory, outputFileName);
                return ConvertWebPToGifAsync(inputPath, outputPath, cts.Token);
            }).ToArray();

            // Await all tasks (they will respect cancellation)
            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronous conversion of a single WebP file to GIF with cancellation support
    private static async Task ConvertWebPToGifAsync(string inputPath, string outputPath, CancellationToken token)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // If cancellation was requested before starting, exit early
        if (token.IsCancellationRequested)
            return;

        // Perform the conversion on a thread-pool thread
        await Task.Run(() =>
        {
            // Check cancellation again inside the task
            if (token.IsCancellationRequested)
                return;

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save as GIF using default options
                // Aspose.Imaging provides GifOptions; using default constructor
                webPImage.Save(outputPath, new GifOptions());
            }
        }, token);
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to let users cancel a large batch of WebP‑to‑GIF conversions in a desktop app without freezing the UI.
 * 2. When a server process must convert many uploaded WebP images to animated GIFs while allowing graceful shutdown on cancellation requests.
 * 3. When building an image‑processing pipeline that transforms a folder of WebP assets to GIF format asynchronously to improve throughput.
 * 4. When integrating Aspose.Imaging into a C# service that requires responsive cancellation handling during long‑running format conversions.
 * 5. When creating a command‑line tool that processes thousands of WebP files into GIFs and needs to respond to user‑initiated abort signals.
 */
