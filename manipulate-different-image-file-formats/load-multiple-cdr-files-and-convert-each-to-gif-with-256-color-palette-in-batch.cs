using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input directory and output directory
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all CDR files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name, .gif extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Configure GIF save options for a 256‑color palette
                    GifOptions gifOptions = new GifOptions
                    {
                        // 8 bits per pixel => 256 colors (ColorResolution is bits‑1)
                        ColorResolution = 7,
                        DoPaletteCorrection = true,
                        // Optional: interlaced can be set if desired
                        Interlaced = false
                    };

                    // Save as GIF using the configured options
                    cdrImage.Save(outputPath, gifOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a graphic design studio needs to batch‑convert CorelDRAW (.cdr) artwork into web‑friendly 256‑color GIFs for quick preview thumbnails.
 * 2. When an e‑learning platform automates the creation of animated GIF slides from legacy CDR diagrams to embed in HTML5 courses.
 * 3. When a digital asset management system processes incoming CDR files and stores low‑size GIF copies for mobile device caching.
 * 4. When a marketing automation tool generates email‑ready GIF banners from a folder of CDR designs, ensuring the 256‑color palette meets email client limits.
 * 5. When a print‑to‑screen workflow converts CDR illustrations into GIFs with a fixed palette for use in legacy point‑of‑sale displays.
 */