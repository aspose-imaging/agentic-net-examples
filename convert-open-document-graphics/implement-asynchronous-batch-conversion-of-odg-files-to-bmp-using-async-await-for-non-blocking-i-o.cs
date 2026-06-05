using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous processing of a single ODG file to BMP
    private static async Task ProcessFileAsync(string inputPath, string outputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image without blocking the calling thread
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Save as BMP using default BMP options
            var bmpOptions = new BmpOptions();
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }

    // Entry point
    static async Task Main()
    {
        try
        {
            // Hard‑coded input files (ODG) and corresponding output files (BMP)
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg",
                @"C:\Images\sample3.odg"
            };

            // Prepare tasks for batch conversion
            var conversionTasks = inputFiles.Select(inputPath =>
            {
                string outputPath = Path.ChangeExtension(inputPath, ".bmp");
                return ProcessFileAsync(inputPath, outputPath);
            }).ToArray();

            // Await all conversions to complete
            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}