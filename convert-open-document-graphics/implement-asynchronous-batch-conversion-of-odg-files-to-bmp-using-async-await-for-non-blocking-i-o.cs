// HOW-TO: Asynchronously Convert Multiple ODG Files To BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hard‑coded list of ODG files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg"
            };

            // Hard‑coded output directory
            string outputDir = @"C:\Images\Converted";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each file asynchronously
            Task[] conversionTasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                conversionTasks[i] = ConvertOdgToBmpAsync(inputPath, outputPath);
            }

            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task ConvertOdgToBmpAsync(string inputPath, string outputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Perform the load‑convert‑save operation on a background thread
        await Task.Run(() =>
        {
            using (Image image = Image.Load(inputPath))
            {
                // BMP specific save options (default configuration)
                BmpOptions bmpOptions = new BmpOptions();

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to process a batch of OpenDocument graphics (ODG) and generate BMP thumbnails without freezing the UI.
 * 2. When a server‑side service must convert user‑uploaded ODG drawings to BMP images in parallel while keeping the request thread responsive.
 * 3. When an automated build pipeline has to transform ODG assets into BMP format for legacy systems that only accept bitmap files.
 * 4. When a cloud function processes large numbers of ODG files and saves the results to a shared folder without blocking other operations.
 * 5. When a migration tool moves graphic resources from ODG to BMP and wants to leverage async/await to improve overall conversion throughput.
 */
