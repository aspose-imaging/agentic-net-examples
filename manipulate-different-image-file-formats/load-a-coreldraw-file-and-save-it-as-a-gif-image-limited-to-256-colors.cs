using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.gif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF save options (256‑color palette)
                var gifOptions = new GifOptions
                {
                    // 7 means 8 bits per primary color (2^8 = 256 colors)
                    ColorResolution = 7,
                    // Analyze source colors to build the best matching palette
                    DoPaletteCorrection = true
                };

                // Save the image as GIF using the configured options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy CorelDRAW (CDR) artwork into a web‑friendly GIF with a 256‑color palette for embedding in HTML emails.
 * 2. When an e‑commerce platform must generate low‑size product thumbnails from CDR source files to meet bandwidth constraints on mobile browsers.
 * 3. When a marketing automation system automates the creation of animated GIF banners from designer‑provided CDR files while ensuring the GIF complies with the 256‑color limit of older browsers.
 * 4. When a document management workflow requires batch conversion of archived CDR drawings to GIF for quick preview in file explorers that only support raster formats.
 * 5. When a game development pipeline needs to import vector assets created in CorelDRAW and export them as indexed GIF sprites to reduce texture memory usage.
 */