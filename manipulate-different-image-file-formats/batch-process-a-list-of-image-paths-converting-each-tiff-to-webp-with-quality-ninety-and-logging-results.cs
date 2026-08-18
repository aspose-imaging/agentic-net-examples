// HOW-TO: Batch Convert Multiple TIFF Files to WebP with Quality 90 in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.tif",
                @"C:\Images\image2.tif",
                @"C:\Images\image3.tif"
            };

            // Hardcoded output directory for WebP files
            string outputDir = @"C:\Images\WebP";

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as WebP with quality 90
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };
                    image.Save(outputPath, webpOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage size of scanned TIFF documents by converting them to high‑quality WebP images in a .NET batch process.
 * 2. When an application must automatically generate WebP versions of a set of TIFF assets for faster web delivery while preserving visual fidelity.
 * 3. When a server‑side service processes a predefined list of TIFF files and logs each successful conversion for audit or troubleshooting.
 * 4. When you want to ensure the output directory exists and create it on‑the‑fly while converting TIFF to WebP in C#.
 * 5. When you require a simple error‑handling loop that skips missing TIFF files and reports conversion errors during bulk image processing.
 */
