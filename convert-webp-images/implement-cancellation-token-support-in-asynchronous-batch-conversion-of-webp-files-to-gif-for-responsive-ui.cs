using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hard‑coded input files (WebP) and output directory (GIF)
    private static readonly string[] InputFiles = new[]
    {
        @"c:\temp\input1.webp",
        @"c:\temp\input2.webp",
        @"c:\temp\input3.webp"
    };

    private const string OutputDirectory = @"c:\temp\output";

    static async Task Main()
    {
        // Ensure the output directory exists (rule 3)
        Directory.CreateDirectory(OutputDirectory);

        // Cancellation token source to allow UI‑style cancellation
        using var cts = new CancellationTokenSource();

        // Example: cancel after 5 seconds (simulating a user cancel action)
        _ = Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            cts.Cancel();
        });

        // Start batch conversion tasks
        var conversionTasks = new Task[InputFiles.Length];
        for (int i = 0; i < InputFiles.Length; i++)
        {
            string inputPath = InputFiles[i];
            string outputPath = Path.Combine(OutputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".gif");

            conversionTasks[i] = ConvertWebPToGifAsync(inputPath, outputPath, cts.Token);
        }

        // Await all tasks; handle cancellation gracefully
        try
        {
            await Task.WhenAll(conversionTasks);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Batch conversion was canceled.");
        }
    }

    // Asynchronous conversion of a single WebP file to GIF with cancellation support
    private static async Task ConvertWebPToGifAsync(string inputPath, string outputPath, CancellationToken token)
    {
        // Input file existence check (rule 2)
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (rule 3)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Run the conversion on a thread‑pool thread to avoid blocking the UI thread
        await Task.Run(() =>
        {
            // Observe cancellation before starting heavy work
            token.ThrowIfCancellationRequested();

            // Load WebP image (using rule‑based creation)
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Observe cancellation again before saving
                token.ThrowIfCancellationRequested();

                // Save as GIF using Aspose.Imaging GIF options
                webPImage.Save(outputPath, new GifOptions());
            }
        }, token);
    }
}