// HOW-TO: Asynchronously Convert Multiple OTG Files To BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input OTG files
            string[] inputFiles = new[]
            {
                @"C:\OTG\Input\sample1.otg",
                @"C:\OTG\Input\sample2.otg"
            };

            var tasks = new List<Task>();

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                tasks.Add(ProcessFileAsync(inputPath));
            }

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ProcessFileAsync(string inputPath)
    {
        // Determine output BMP path
        string outputPath = Path.ChangeExtension(inputPath, ".bmp");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image asynchronously
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Configure rasterization options based on source image size
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options and attach rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the image as BMP asynchronously
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process a set of OTG vector drawings into BMP raster images without blocking the UI thread in a C# desktop or web application.
 * 2. When a server‑side service must convert incoming OTG files to BMP for downstream legacy systems while handling many requests concurrently.
 * 3. When you want to automate conversion of OTG assets stored on disk to BMP thumbnails using async/await to improve throughput.
 * 4. When integrating Aspose.Imaging into a CI/CD pipeline that validates OTG files by converting them to BMP in parallel to speed up build times.
 * 5. When developing a cloud function that receives OTG uploads and must save them as BMP images without tying up compute resources.
 */
