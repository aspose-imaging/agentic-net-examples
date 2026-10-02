// HOW-TO: Convert SVG to BMP and Rotate Image 90 Degrees Clockwise in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string bmpPath = "output.bmp";

            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath) ?? ".");

            // Convert SVG to BMP
            using (Image svgImage = Image.Load(svgPath))
            {
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };
                svgImage.Save(bmpPath, bmpOptions);
            }

            // Load BMP, rotate 90 degrees clockwise, and save
            using (RasterImage bmpImage = (RasterImage)Image.Load(bmpPath))
            {
                bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                // Ensure directory again (in case it was changed)
                Directory.CreateDirectory(Path.GetDirectoryName(bmpPath) ?? ".");
                bmpImage.Save(bmpPath);
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
 * 1. When you need to generate a bitmap thumbnail from an SVG logo and ensure it is oriented correctly for display in a Windows desktop application.
 * 2. When a batch process must convert vector graphics to BMP format for legacy systems that only accept raster images, while also rotating them to match a predefined layout.
 * 3. When preparing assets for printing where the SVG artwork must be rasterized to BMP and rotated 90 degrees to align with the printer’s paper orientation.
 * 4. When creating game textures from SVG icons and the engine requires BMP files that are pre‑rotated to fit the sprite sheet orientation.
 * 5. When automating the conversion of SVG diagrams to BMP for inclusion in PDF reports, and the diagrams need to be rotated clockwise to match the report’s page layout.
 */
