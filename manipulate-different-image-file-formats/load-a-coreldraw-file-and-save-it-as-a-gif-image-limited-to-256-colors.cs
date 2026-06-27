using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF save options for 256‑color output
                GifOptions gifOptions = new GifOptions
                {
                    // ColorResolution = bits per primary color minus 1 (7 => 8 bits => 256 colors)
                    ColorResolution = 7,
                    // Enable palette correction for best matching palette
                    DoPaletteCorrection = true
                };

                // Save as GIF using the configured options
                image.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to convert a multi‑layer CorelDRAW (CDR) design into a web‑friendly GIF with a 256‑color palette for faster page loads.
 * 2. When an e‑commerce platform must generate product thumbnails from CDR files that can be displayed in legacy browsers supporting only 8‑bit GIF images.
 * 3. When an automated reporting tool has to embed vector artwork from CorelDRAW into email newsletters that require GIF attachments limited to 256 colors.
 * 4. When a digital asset management system must archive CDR drawings as size‑optimized GIFs for long‑term storage while preserving visual fidelity through palette correction.
 * 5. When a batch‑processing script needs to convert a library of CorelDRAW files to 256‑color GIFs for use in a mobile app that only supports GIF images with limited color depth.
 */