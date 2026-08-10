// HOW-TO: Resize EPS to Double Size and Save as High‑Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Calculate double dimensions
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save as high‑resolution PNG
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
 * 1. When you need to enlarge a vector EPS logo for printing on large banners while preserving quality by converting it to a high‑resolution PNG.
 * 2. When a web application must generate a zoomed‑in preview of an EPS diagram for detailed inspection in a browser.
 * 3. When an automated workflow processes EPS artwork and creates double‑sized PNG assets for high‑DPI displays.
 * 4. When a desktop tool resizes EPS icons to twice their original size to match modern UI guidelines and saves them as PNG files.
 * 5. When a batch script converts legacy EPS files to high‑resolution PNGs with doubled dimensions for archival or sharing purposes.
 */
