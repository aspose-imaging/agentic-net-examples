// HOW-TO: Convert EMF to GIF with 256‑Color Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole process to catch unexpected errors
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.gif";

            // Verify that the source EMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF saving options with a limited 256‑color palette
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction to build the best matching 256‑color palette
                    DoPaletteCorrection = true,
                    // Set color resolution (bits per primary color minus 1). 7 => 8 bits per channel.
                    ColorResolution = 7
                };

                // Save the image as GIF using the configured options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed vector EMF graphics into a web page that only supports GIF images with a 256‑color limit.
 * 2. When converting legacy Windows Metafile reports to GIF for email attachments that must stay under size restrictions.
 * 3. When generating thumbnails from EMF diagrams for a mobile app that requires GIF format with a fixed palette.
 * 4. When preparing EMF icons for a content management system that only accepts GIF files with palette correction.
 * 5. When automating batch conversion of EMF assets to GIF to ensure compatibility with older browsers that cannot render more than 256 colors.
 */
