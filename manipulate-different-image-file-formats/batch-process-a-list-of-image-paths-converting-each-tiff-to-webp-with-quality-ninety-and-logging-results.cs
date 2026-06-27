using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of TIFF files to convert
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input\image1.tif",
                @"C:\Images\Input\image2.tif",
                @"C:\Images\Input\image3.tif"
            };

            // Output directory (hardcoded)
            string outputDirectory = @"C:\Images\Output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .webp extension
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory exists
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
 * 1. When a developer needs to migrate a legacy archive of TIFF photographs to the modern WebP format to reduce storage size while preserving visual quality at 90% using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must batch‑convert product catalog TIFF images to WebP for faster web page loading and SEO‑friendly image delivery.
 * 3. When a medical imaging application requires automated conversion of scanned TIFF radiology images to WebP for efficient transmission to remote diagnostic tools.
 * 4. When a content management system needs to process a predefined list of TIFF assets nightly, saving them as WebP with consistent quality and logging each conversion result.
 * 5. When a developer builds a Windows service that validates the existence of TIFF files, creates the output directory, and converts them to WebP with Aspose.Imaging while handling errors gracefully.
 */