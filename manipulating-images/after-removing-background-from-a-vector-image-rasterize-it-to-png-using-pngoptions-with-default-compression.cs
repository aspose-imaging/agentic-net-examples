// HOW-TO: How To Remove Background From SVG And Save As PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Remove background if it's a vector image
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground();
                }

                // Prepare PNG options with default compression
                PngOptions pngOptions = new PngOptions();

                // Save rasterized PNG
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
 * 1. When you need to strip the white or colored background from an SVG logo before embedding it in a web page as a PNG thumbnail.
 * 2. When an automated image pipeline must convert vector illustrations to raster PNGs with default compression for faster loading on mobile devices.
 * 3. When generating product catalog images where the original SVG files contain unwanted background layers that must be removed prior to printing.
 * 4. When creating PDF reports that require PNG snapshots of vector diagrams without any background to maintain a transparent look.
 * 5. When building a C# desktop application that lets users import SVG icons, cleans the background, and saves them as PNG files for use in UI controls.
 */
