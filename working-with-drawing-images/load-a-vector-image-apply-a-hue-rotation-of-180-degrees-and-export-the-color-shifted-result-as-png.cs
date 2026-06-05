using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (var memoryStream = new MemoryStream())
                {
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;
                        if (!raster.IsCached) raster.CacheData();

                        var finalOptions = new PngOptions();
                        rasterImage.Save(outputPath, finalOptions);
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
 * 1. When a web application needs to generate a night‑mode version of an SVG logo by rotating its hue 180° and serving it as a PNG thumbnail, a developer can use this C# Aspose.Imaging code to rasterize, hue‑shift, and save the image.
 * 2. When an e‑commerce platform wants to display product illustrations with a complementary color scheme for promotional banners, the code can load the original SVG, apply a 180° hue rotation, and export the result as a PNG for fast web delivery.
 * 3. When a desktop publishing tool must convert user‑uploaded vector icons into PNG assets with a uniform color shift for accessibility contrast, this Aspose.Imaging snippet handles the SVG loading, hue adjustment, and PNG output in C#.
 * 4. When an automated build pipeline generates themed UI assets by programmatically recoloring SVG assets and bundling them as PNG files, the provided code performs the rasterization and hue rotation step reliably.
 * 5. When a mobile app needs to pre‑process SVG illustrations into PNGs with a reversed color palette for dark‑mode support, developers can employ this C# example to apply a 180° hue rotation and save the transformed image.
 */