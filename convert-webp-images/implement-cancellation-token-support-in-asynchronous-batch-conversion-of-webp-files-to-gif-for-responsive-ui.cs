using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    // Hardcoded input directory and output directory
    private const string InputDirectory = @"C:\Images\Input\";
    private const string OutputDirectory = @"C:\Images\Output\";

    static async Task Main()
    {
        // Example list of WebP files to convert
        string[] webpFiles = new[]
        {
            Path.Combine(InputDirectory, "image1.webp"),
            Path.Combine(InputDirectory, "image2.webp"),
            Path.Combine(InputDirectory, "image3.webp")
        };

        // Create a cancellation token source that can be triggered by the user
        using var cts = new CancellationTokenSource();

        // Optional: cancel after a fixed time (e.g., 10 seconds) to simulate UI cancellation
        // Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ => cts.Cancel());

        // Listen for a key press to cancel
        Task.Run(() =>
        {
            Console.WriteLine("Press 'c' to cancel the batch conversion...");
            while (Console.ReadKey(true).KeyChar != 'c') { }
            cts.Cancel();
        });

        // Process all files asynchronously
        var conversionTasks = webpFiles.Select(inputPath => ConvertWebPToGifAsync(inputPath, cts.Token));
        try
        {
            await Task.WhenAll(conversionTasks);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Batch conversion was canceled.");
        }
    }

    private static async Task ConvertWebPToGifAsync(string inputPath, CancellationToken token)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Prepare output path (same file name with .gif extension)
        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
        string outputPath = Path.Combine(OutputDirectory, outputFileName);

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Check for cancellation before starting heavy work
        if (token.IsCancellationRequested)
        {
            token.ThrowIfCancellationRequested();
        }

        // Load the WebP image and save as GIF inside a background task
        await Task.Run(() =>
        {
            // Respect cancellation inside the task
            token.ThrowIfCancellationRequested();

            // Load the WebP image (using generic Image.Load for flexibility)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare GIF save options (default options are sufficient for basic conversion)
                var gifOptions = new GifOptions();

                // Save the image as GIF
                image.Save(outputPath, gifOptions);
            }
        }, token);
    }
}