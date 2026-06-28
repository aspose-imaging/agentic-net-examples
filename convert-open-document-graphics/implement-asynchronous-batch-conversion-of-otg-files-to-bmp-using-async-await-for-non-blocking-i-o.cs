using System;
using System.IO;
using System.Threading.Tasks;
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
                @"C:\Input\sample1.otg",
                @"C:\Input\sample2.otg"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output";

            foreach (var inputPath in inputFiles)
            {
                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output BMP path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Perform asynchronous conversion
                await ConvertOtgToBmpAsync(inputPath, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertOtgToBmpAsync(string inputPath, string outputPath)
    {
        // Load the OTG image on a background thread
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Configure rasterization options to match source size
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set BMP save options and attach rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the image as BMP on a background thread
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a GIS application needs to generate thumbnail BMP previews of multiple OTG vector maps without freezing the UI, developers can use this async batch conversion code.
 * 2. When an automated document processing pipeline must convert incoming OTG drawings to BMP for legacy reporting tools, the asynchronous method allows non‑blocking I/O and faster throughput.
 * 3. When a cloud‑based microservice receives a batch of OTG files and must store them as BMP images in a shared folder, developers can employ this code to handle the conversions concurrently.
 * 4. When a Windows desktop utility needs to export a series of OTG engineering schematics to BMP for printing on devices that only support raster formats, the async/await pattern keeps the application responsive.
 * 5. When a scheduled background job processes nightly OTG uploads and creates BMP assets for a web gallery, this asynchronous batch conversion ensures the job runs efficiently without blocking other services.
 */