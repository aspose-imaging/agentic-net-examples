using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Example filter: no modification, just conversion.
                // Additional processing can be added here (e.g., resizing, color adjustments).

                // Save as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG icons and store them as PNG files on the server for fast rendering.
 * 2. When an automated build pipeline converts vector graphics from design assets (SVG) into raster PNGs for inclusion in mobile app resource bundles.
 * 3. When a reporting tool extracts SVG charts from a data visualization library and saves them as PNG images to embed in PDF or email reports.
 * 4. When a desktop utility processes SVG logos, applies optional filters such as resizing or color adjustments, and writes the final PNG files to a shared output directory.
 * 5. When a content management system validates the existence of an SVG file, creates the target folder if missing, and uses Aspose.Imaging to convert the vector image to PNG for browser‑compatible delivery.
 */