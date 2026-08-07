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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.gif";

            // Verify input file exists
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
                // Configure GIF save options (256‑color limit is inherent to GIF)
                GifOptions gifOptions = new GifOptions
                {
                    // Maximum color resolution (7 => 8 bits per primary color)
                    ColorResolution = 7,
                    // Enable palette correction for best matching palette
                    DoPaletteCorrection = true,
                    // Optional: set interlaced to false for a standard GIF
                    Interlaced = false
                };

                // Save the image as GIF
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
 * 1. When a developer needs to convert legacy CorelDRAW (CDR) artwork into a web‑friendly GIF with a 256‑color palette for inclusion in HTML emails.
 * 2. When an automated build pipeline must generate low‑size preview thumbnails of CDR files for a digital asset management system.
 * 3. When a Windows desktop application has to export vector drawings from CorelDRAW to GIF for compatibility with older browsers that only support 8‑bit images.
 * 4. When a batch‑processing script is required to transform a folder of CDR logos into GIF icons while ensuring palette correction for accurate colors.
 * 5. When a content‑management system needs to display user‑uploaded CorelDRAW designs as animated or static GIFs with a guaranteed 256‑color limit to meet file‑size constraints.
 */