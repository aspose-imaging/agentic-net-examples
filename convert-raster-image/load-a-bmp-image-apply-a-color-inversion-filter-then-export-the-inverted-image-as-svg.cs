using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        var original = raster.GetPixel(x, y);
                        var inverted = Color.FromArgb(
                            original.A,
                            255 - original.R,
                            255 - original.G,
                            255 - original.B);
                        raster.SetPixel(x, y, inverted);
                    }
                }

                // Save the inverted image as SVG
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
 * 1. When a developer needs to convert legacy BMP assets to scalable SVG for responsive web design while applying a negative color effect.
 * 2. When an application must generate high‑contrast SVG icons from bitmap screenshots for accessibility compliance.
 * 3. When a batch‑processing tool has to invert colors of scanned BMP diagrams and export them as vector SVG files for printing.
 * 4. When a game engine pipeline requires turning BMP textures into SVG sprites with inverted colors for a night‑mode visual style.
 * 5. When a document generation system needs to embed an inverted‑color version of a BMP logo as an SVG image in PDF reports.
 */