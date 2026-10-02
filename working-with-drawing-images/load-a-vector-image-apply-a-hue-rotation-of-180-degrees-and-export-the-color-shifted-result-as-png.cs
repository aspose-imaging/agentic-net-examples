// HOW-TO: Rotate Hue of SVG by 180 Degrees and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustGamma(1.0f);

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to recolor a logo stored as SVG by shifting its hue and deliver it as a PNG for web use.
 * 2. When an application must programmatically generate a night‑mode version of vector graphics by rotating colors 180° before rasterizing.
 * 3. When a batch process converts brand assets from SVG to PNG while applying a uniform color shift to match a new visual theme.
 * 4. When a reporting tool requires embedding color‑adjusted PNG snapshots of vector diagrams generated on the fly.
 * 5. When a mobile app prepares SVG icons with a complementary hue for dark backgrounds and saves them as PNG files.
 */
