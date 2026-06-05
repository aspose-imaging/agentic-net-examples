using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of TIFF files to process
            var inputPaths = new[]
            {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif",
                @"C:\Images\sample3.tif"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output WebP file path (same folder, .webp extension)
                var outputPath = Path.ChangeExtension(inputPath, ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as WebP with quality 90
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };
                    image.Save(outputPath, webpOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce storage size of scanned documents by converting a batch of high‑resolution TIFF files to WebP with 90 % quality for faster web delivery.
 * 2. When an e‑commerce platform must automatically generate lightweight product images from legacy TIFF assets for mobile browsers using C# and Aspose.Imaging.
 * 3. When a digital archiving system requires a scheduled job that validates TIFF file existence, converts them to WebP, and logs each conversion for audit trails.
 * 4. When a photo‑editing application wants to provide users a one‑click export of selected TIFF photos to WebP format while preserving visual fidelity with a quality setting of 90.
 * 5. When a content management workflow needs to batch‑process incoming TIFF uploads, create WebP versions in the same folder, and output conversion results to the console for monitoring.
 */