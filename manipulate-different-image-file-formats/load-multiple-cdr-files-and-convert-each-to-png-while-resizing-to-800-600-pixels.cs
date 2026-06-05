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
            // Hard‑coded list of input CDR files
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr",
                @"C:\Images\sample3.cdr"
            };

            // Hard‑coded output directory (PNG files will be placed here)
            string outputDir = @"C:\Images\Converted";

            // Ensure the output directory exists once (additional calls are harmless)
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output file name (same base name with .png extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR file
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Resize the image to 800x600 (default NearestNeighbourResample)
                    cdrImage.Resize(800, 600);

                    // Prepare PNG save options (optional, can be default)
                    PngOptions pngOptions = new PngOptions();

                    // Save as PNG
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
 * 1. When a developer needs to batch‑convert a collection of CorelDRAW (.cdr) design files into web‑ready PNG thumbnails of 800×600 pixels for an online portfolio.
 * 2. When an e‑commerce platform must automatically generate uniformly sized product preview images from supplier‑provided CDR artwork during the import process.
 * 3. When a digital asset management system requires a nightly job that transforms newly uploaded CDR logos into 800×600 PNG files for quick preview in the UI.
 * 4. When a marketing automation tool has to resize and convert multiple CDR banner drafts into PNG format before sending them to an email‑campaign service.
 * 5. When a desktop application needs to read several CDR files, downscale them to 800×600, and save them as PNGs for inclusion in a PDF report generated with Aspose.PDF.
 */