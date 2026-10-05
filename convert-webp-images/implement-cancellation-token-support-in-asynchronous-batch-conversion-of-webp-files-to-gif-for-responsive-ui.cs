// HOW-TO: Asynchronously Convert Multiple WebP Files To GIF With Cancellation Support In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputDirectory = "input";
            string outputDirectory = "output";

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            var inputFiles = Directory.GetFiles(inputDirectory, "*.webp");

            var tasks = inputFiles.Select(inputPath =>
            {
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".gif");
                return ConvertWebpToGifAsync(inputPath, outputPath, cts.Token);
            });

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertWebpToGifAsync(string inputPath, string outputPath, CancellationToken cancellationToken)
    {
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        await Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var image = Image.Load(inputPath))
            {
                cancellationToken.ThrowIfCancellationRequested();

                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }
        }, cancellationToken);
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert a folder of WebP images to GIFs without freezing the UI, using async processing and cancellation.
 * 2. When you want to let users abort a long‑running image conversion operation (for example, pressing Ctrl‑C) and release resources promptly.
 * 3. When you are building a desktop or server tool that processes many WebP files in parallel and must handle missing files gracefully.
 * 4. When you need to ensure the output directory is created automatically during a bulk conversion of WebP to GIF.
 * 5. When you require a simple way to integrate Aspose.Imaging’s WebP loading and GIF saving into a C# application with cancellation token support.
 */
