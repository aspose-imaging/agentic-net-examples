// HOW-TO: Apply Gaussian Blur to SVG and Export High‑Quality PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";
            string tempPath = "temp/temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var tempOptions = new PngOptions();
                vectorImage.Save(tempPath, tempOptions);
            }

            using (Image tempImage = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)tempImage;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 1.0));

                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    BitDepth = 8,
                    FilterType = PngFilterType.Adaptive
                };
                raster.Save(outputPath, saveOptions);
            }

            File.Delete(tempPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert an SVG logo into a blurred PNG thumbnail for a web page while preserving transparency.
 * 2. When you want to generate high‑resolution PNG assets from vector illustrations with a soft focus effect for print or UI design.
 * 3. When an application must programmatically rasterize SVG icons, apply a Gaussian blur, and save them with optimal PNG compression settings.
 * 4. When you are building a batch‑processing tool that adds a subtle blur to vector graphics before uploading them to a digital asset management system.
 * 5. When you require a C# solution to render vector artwork, apply image filtering, and output a true‑color PNG with alpha channel for use in mobile apps.
 */
