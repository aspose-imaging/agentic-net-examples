// HOW-TO: Convert SVG to PNG with Default Rasterization Options in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(stream))
            {
                // Set up default rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

                // Configure PNG save options with the rasterization settings
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as PNG
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When you need to generate raster PNG thumbnails from vector SVG assets for web display using Aspose.Imaging in a C# application.
 * 2. When an automated build process must batch‑convert design SVG files into PNGs for inclusion in mobile app resources without custom raster settings.
 * 3. When a reporting tool requires embedding high‑quality PNG images derived from SVG charts, and you want a simple default rasterization approach.
 * 4. When a server‑side service receives uploaded SVG logos and must store them as PNG files for compatibility with legacy browsers.
 * 5. When you are creating a document conversion pipeline that transforms vector graphics into PNG format for PDF generation using C# and Aspose.Imaging.
 */
