// HOW-TO: Convert PNG to SVG with 16-Color Palette Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with pixel data
                RasterImage raster = (RasterImage)image;

                // Generate a 16‑color palette using the histogram mining method
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(
                    raster,
                    16,
                    PaletteMiningMethod.Histogram);

                // Prepare SVG save options and assign the palette
                var svgOptions = new SvgOptions
                {
                    Palette = palette
                };

                // Save the image as SVG with the reduced palette
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a small PNG graphic in a web page as scalable SVG while limiting colors to reduce file size.
 * 2. When converting legacy PNG icons to SVG for responsive UI designs and you want a fixed 16‑color palette for consistency.
 * 3. When generating SVG assets for printing or laser cutting and you must ensure the image uses a limited palette to match device constraints.
 * 4. When optimizing graphics for low‑bandwidth mobile apps by converting PNGs to SVG with a reduced color set using C#.
 * 5. When automating batch processing of PNG assets to SVG with a specific palette for a design system using Aspose.Imaging.
 */
