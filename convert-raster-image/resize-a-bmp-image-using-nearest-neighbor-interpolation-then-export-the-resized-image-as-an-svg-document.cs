// HOW-TO: Resize BMP Image with Nearest Neighbor and Export as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                int newWidth = 200;   // desired width
                int newHeight = 200;  // desired height

                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a scalable vector version of a low‑resolution BMP thumbnail for responsive web design.
 * 2. When you must quickly downscale a large bitmap to a fixed size using nearest‑neighbor to preserve hard edges before converting it to SVG for printing.
 * 3. When an application processes legacy BMP assets and requires them in SVG format for modern UI components without losing pixel‑art style.
 * 4. When a batch job converts BMP icons to SVG icons with exact dimensions for use in mobile apps, ensuring fast processing with nearest‑neighbor interpolation.
 * 5. When a developer wants to programmatically resize a BMP logo to 200 × 200 pixels and output it as an SVG file for inclusion in vector‑based reports.
 */
