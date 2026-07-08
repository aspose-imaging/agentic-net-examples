using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Set color mode to Grayscale for monochrome output
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD with the specified options
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a color BMP image to a grayscale Photoshop PSD for printing black‑and‑white brochures using Aspose.Imaging in C#.
 * 2. When an automated batch‑processing service must generate monochrome PSD assets from scanned documents to reduce file size and simplify downstream editing.
 * 3. When a web application creates preview PSD files in grayscale for a digital art workflow that requires consistent color mode across all layers.
 * 4. When a desktop utility transforms product photos into grayscale PSDs to meet a brand’s visual guidelines before handing them off to designers.
 * 5. When a migration script moves legacy bitmap assets into Photoshop format while enforcing a grayscale color mode to ensure compatibility with older PSD viewers.
 */