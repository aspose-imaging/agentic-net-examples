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
            string[] inputPaths = {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Converted";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists (rule requirement)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Resize to 800x600 pixels
                    cdrImage.Resize(800, 600);

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
 * 1. When a .NET developer needs to batch‑convert a collection of CorelDRAW (CDR) files into web‑friendly PNG images sized to 800 × 600 pixels for faster page loads.
 * 2. When an e‑commerce platform must automatically generate thumbnail PNG previews from designer‑provided CDR assets during product import.
 * 3. When a digital asset management system requires a scheduled job that reads multiple CDR files, resizes them to a standard 800 × 600 resolution, and stores the PNG versions for consistent catalog display.
 * 4. When a marketing automation tool has to transform client‑supplied CDR logos into 800 × 600 PNG files for inclusion in email campaigns and social media posts.
 * 5. When a desktop application needs to validate the existence of CDR source files, resize each to 800 × 600, and save them as PNG using Aspose.Imaging for .NET before archiving them in a shared folder.
 */