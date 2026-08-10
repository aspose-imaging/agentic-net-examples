// HOW-TO: Invert BMP Colors And Save As SVG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input\\sample.bmp";
            string outputPath = "output\\inverted.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to raster image for pixel manipulation
                var raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

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

                // Save the processed image as SVG
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
 * 1. When you need to convert legacy BMP icons to scalable SVG graphics with a negative color scheme for a dark‑mode UI.
 * 2. When generating high‑contrast negative images for computer‑vision preprocessing or visual analysis.
 * 3. When preparing web assets that require SVG format but the source files are BMPs that must be color‑inverted for branding.
 * 4. When creating accessible, high‑visibility graphics by inverting colors of BMP illustrations before exporting them as SVG.
 * 5. When batch‑processing scanned BMP documents to produce inverted, resolution‑independent SVG files for printing or archiving.
 */
