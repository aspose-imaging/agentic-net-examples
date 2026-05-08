using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;

class Program
{
    static async Task Main()
    {
        // Hardcoded input files and output directory
        string[] inputFiles = new[]
        {
            @"c:\temp\input1.webp",
            @"c:\temp\input2.webp",
            @"c:\temp\input3.webp"
        };
        string outputDirectory = @"c:\temp\output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Cancellation token source for demonstration (cancel after 10 seconds)
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(10));

        try
        {
            await ConvertWebPToGifBatchAsync(inputFiles, outputDirectory, cts.Token);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronous batch conversion with cancellation support
    private static async Task ConvertWebPToGifBatchAsync(string[] inputPaths, string outputDir, CancellationToken token)
    {
        // Process each file sequentially; replace with Parallel.ForEachAsync for parallelism if desired
        foreach (var inputPath in inputPaths)
        {
            token.ThrowIfCancellationRequested();

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output path
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".gif");

            // Ensure output directory exists (already created in Main, but follow rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as GIF using default options
                    await Task.Run(() => image.Save(outputPath, new GifOptions()), token);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Conversion canceled.");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to convert {inputPath}: {ex.Message}");
            }
        }
    }
}