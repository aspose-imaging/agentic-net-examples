// HOW-TO: Asynchronously Convert Multiple ODG Files to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Get all ODG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.odg");

            // Create conversion tasks
            Task[] conversionTasks = inputFiles.Select(inputPath =>
            {
                // Determine output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                return ConvertOdgToBmpAsync(inputPath, outputPath);
            }).ToArray();

            // Await all conversions
            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertOdgToBmpAsync(string inputPath, string outputPath)
    {
        // Check input file existence
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
                // Set BMP options (default)
                BmpOptions bmpOptions = new BmpOptions();

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate BMP thumbnails from many user‑uploaded ODG drawings without blocking the request thread.
 * 2. When a background service processes a folder of ODG design files overnight and saves them as BMP for legacy systems that only accept bitmap images.
 * 3. When a desktop utility batch‑converts a large collection of ODG diagrams to BMP for inclusion in a PowerPoint presentation, using async/await to keep the UI responsive.
 * 4. When a cloud function receives ODG files from a queue and must quickly convert them to BMP for downstream image‑processing pipelines while maximizing throughput.
 * 5. When an automated testing framework validates that ODG files are correctly rendered by converting them to BMP and comparing pixel data, running conversions in parallel to reduce test time.
 */
