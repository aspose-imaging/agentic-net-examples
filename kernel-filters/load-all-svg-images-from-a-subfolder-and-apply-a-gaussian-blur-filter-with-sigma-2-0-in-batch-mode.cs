// HOW-TO: Batch Convert SVG to PNG with Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_svgs";
            string outputFolder = "output_svgs";

            Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    SvgImage svgImage = (SvgImage)image;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, new PngOptions());
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 2.0));
                            raster.Save(outputPath, new PngOptions());
                        }
                    }
                }
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
 * 1. When you need to automatically blur and export a large set of vector icons to PNG for a web UI.
 * 2. When generating preview thumbnails of SVG diagrams with a soft focus effect for a documentation portal.
 * 3. When preprocessing SVG artwork before printing by converting it to raster PNG and applying a uniform blur to reduce sharp edges.
 * 4. When creating a batch pipeline that transforms user‑uploaded SVG logos into blurred PNG assets for a marketing campaign.
 * 5. When building a C# tool that rasterizes SVG files and applies a Gaussian blur filter to meet a design specification for mobile app assets.
 */
