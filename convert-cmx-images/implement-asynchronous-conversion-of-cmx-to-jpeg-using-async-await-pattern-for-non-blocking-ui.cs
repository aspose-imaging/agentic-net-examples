// HOW-TO: Asynchronously Convert Cmx Files To Jpeg In C# With Async Await (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    // Asynchronous conversion method
    private static async Task ConvertCmxToJpegAsync(string inputPath, string outputPath)
    {
        // Load CMX image (synchronous, wrapped in Task.Run for async behavior)
        using (CmxImage cmxImage = await Task.Run(() => (CmxImage)Image.Load(inputPath)))
        {
            // Prepare JPEG save options
            var jpegOptions = new JpegOptions
            {
                // Example: set quality if needed
                Quality = 90
            };

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save as JPEG (synchronous, wrapped in Task.Run)
            await Task.Run(() => cmxImage.Save(outputPath, jpegOptions));
        }
    }

    static async Task Main()
    {
        // Hardcoded paths
        string inputPath = "sample.cmx";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Perform conversion
            await ConvertCmxToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows desktop application needs to load legacy CorelDRAW Cmx drawings and display them as JPEG thumbnails without freezing the UI.
 * 2. When a web service processes uploaded Cmx artwork and returns compressed JPEG previews while keeping the request thread responsive.
 * 3. When a batch conversion tool runs on a background thread to transform multiple Cmx files into JPEGs without blocking other operations.
 * 4. When a mobile app using Xamarin converts Cmx vector images to JPEG for sharing, using async/await to maintain smooth user interactions.
 * 5. When an automated reporting system generates JPEG snapshots from Cmx source files as part of a scheduled pipeline, ensuring the conversion runs asynchronously.
 */
