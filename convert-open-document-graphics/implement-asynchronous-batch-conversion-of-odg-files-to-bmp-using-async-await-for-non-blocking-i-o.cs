using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

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

        await Task.Run(() =>
        {
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP options with rasterization settings
                var bmpOptions = new BmpOptions();

                // Configure vector rasterization for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }
        });
    }

    // Entry point
    static async Task Main()
    {
        // Hardcoded input files and output directory
        string[] inputFiles = new[]
        {
            @"C:\Input\sample1.odg",
            @"C:\Input\sample2.odg",
            @"C:\Input\sample3.odg"
        };
        string outputDirectory = @"C:\Output";

        // Prepare tasks for batch conversion
        var tasks = inputFiles.Select(inputPath =>
        {
            string outputPath = Path.Combine(
                outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
            return ProcessFileAsync(inputPath, outputPath);
        }).ToArray();

        // Await all conversions
        await Task.WhenAll(tasks);
    }
}