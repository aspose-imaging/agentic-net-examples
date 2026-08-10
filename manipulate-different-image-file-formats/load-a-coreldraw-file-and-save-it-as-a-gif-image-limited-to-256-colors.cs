// HOW-TO: Convert CorelDRAW CDR to 256‑Color GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

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

            // Load the CorelDRAW (CDR) image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Configure GIF save options
                GifOptions gifOptions = new GifOptions
                {
                    // Use palette correction to build the best matching 256‑color palette
                    DoPaletteCorrection = true,
                    // Set color resolution (bits per primary color minus 1). 7 => 8 bits per channel.
                    ColorResolution = 7,
                    // No lossy compression; keep the palette as is
                    MaxDiff = 0
                };

                // Save the image as GIF with the specified options
                cdrImage.Save(outputPath, gifOptions);
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
 * 1. When you need to embed a CorelDRAW illustration into a web page that only supports GIF with a 256‑color palette.
 * 2. When you must generate a lightweight preview of a CDR file for email attachments that require GIF format.
 * 3. When an automated batch process converts legacy CDR assets to GIF for compatibility with older graphics software.
 * 4. When you are creating animated slideshows and need each frame from a CDR source saved as a 256‑color GIF.
 * 5. When a content management system stores user‑uploaded CDR files and needs to display them as GIF thumbnails.
 */
