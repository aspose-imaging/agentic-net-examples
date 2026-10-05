// HOW-TO: Convert JPEG to SVG with Crop and Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var cropRect = new Rectangle(0, 0, 400, 400);
                image.Crop(cropRect);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                image.Filter(image.Bounds, blurOptions);

                var svgOptions = new SvgOptions();
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
 * 1. When you need to generate a vector‑based thumbnail of a specific 400 × 400 area of a photo with a soft focus effect for web previews.
 * 2. When you want to preprocess a high‑resolution raster image by extracting a 400 × 400 region and applying a Gaussian blur before embedding it in an SVG diagram.
 * 3. When creating responsive UI icons that require a blurred raster source converted to scalable SVG for different screen densities.
 * 4. When automating batch processing to crop and blur sections of JPEG assets and store them as lightweight SVG files for faster loading in browsers.
 * 5. When integrating image manipulation into a C# application that must output blurred, cropped graphics in SVG format for downstream vector‑based editing tools.
 */
