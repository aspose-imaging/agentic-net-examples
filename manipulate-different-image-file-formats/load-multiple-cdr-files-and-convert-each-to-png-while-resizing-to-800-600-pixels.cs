using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = new[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Converted";

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Resize to 800x600 pixels
                    cdrImage.Resize(800, 600);

                    // Determine output PNG path
                    string outputPath = Path.Combine(outputDir,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    PngOptions pngOptions = new PngOptions();
                    cdrImage.Save(outputPath, pngOptions);
                }
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
 * 1. When a graphic design studio needs to batch‑convert legacy CorelDRAW (.cdr) artwork into web‑ready PNG thumbnails sized to 800×600 for online portfolios.
 * 2. When an e‑learning platform must automatically resize and transform multiple CDR lesson diagrams into PNG images for inclusion in HTML course pages.
 * 3. When a document management system processes incoming CDR files and stores them as standardized 800×600 PNG previews to enable quick visual indexing.
 * 4. When a marketing automation tool generates PNG banners from a set of CDR templates, ensuring each output matches the required 800×600 pixel dimensions for email campaigns.
 * 5. When a cloud‑based image processing service receives CDR uploads and needs to resize them to 800×600 before saving them as PNG files for downstream analytics.
 */