using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;

class Program
{
    // Hardcoded input and output directories
    private const string InputDirectory = "c:\\temp\\webp\\";
    private const string OutputDirectory = "c:\\temp\\gif\\";

    static async Task Main()
    {
        try
        {
            // Create a cancellation token source that can be triggered by the user
            using var cts = new CancellationTokenSource();

            // Start a task that listens for a key press to cancel the operation
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

            // Get all WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(InputDirectory, "*.webp");

            // Prepare conversion tasks
            var conversionTasks = inputFiles.Select(inputPath => ConvertWebPToGifAsync(inputPath, cts.Token)).ToArray();

            // Await all tasks (they will observe the cancellation token)
            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
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

        // Determine output path
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
        string outputPath = Path.Combine(OutputDirectory, fileNameWithoutExt + ".gif");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Observe cancellation before starting heavy work
        token.ThrowIfCancellationRequested();

        // Load WebP image and save as GIF
        await Task.Run(() =>
        {
            // Check cancellation inside the task as well
            token.ThrowIfCancellationRequested();

            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save to GIF using default options
                webPImage.Save(outputPath, new GifOptions());
            }
        }, token);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop photo‑management app needs to let users convert a large folder of WebP images to GIFs without freezing the UI, the async batch conversion with a cancellation token lets the operation be stopped instantly.
 * 2. When an online content‑creation tool processes user‑uploaded WebP graphics into animated GIFs and must honor a “Cancel” button to avoid unnecessary server load, this code provides responsive cancellation.
 * 3. When a mobile game editor batch‑converts WebP sprites to GIFs for legacy platform support and needs to abort the process if the developer runs out of time or battery, the cancellation token enables graceful termination.
 * 4. When a digital marketing dashboard generates GIF previews from WebP assets in the background and the user navigates away, the code’s cancellation support prevents wasted CPU cycles.
 * 5. When an automated CI/CD pipeline converts WebP assets to GIFs as part of a build step and a developer wants to stop the job early due to a failing test, the cancellation token allows immediate interruption.
 */