// HOW-TO: Apply Gaussian Blur to BMP and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.bmp";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load as RasterImage.");
                    return;
                }

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                {
                    Radius = 1,
                    Sigma = 1.5f
                };

                raster.Filter(raster.Bounds, blurOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to soften the edges of a scanned BMP photograph before converting it to a web‑friendly PNG format using C#.
 * 2. When you want to preprocess legacy BMP assets with a 1.5 sigma Gaussian blur for consistent visual style in a .NET application.
 * 3. When you are building an automated pipeline that applies a subtle blur to BMP screenshots and stores the results as lossless PNG files.
 * 4. When you must reduce high‑frequency noise in BMP medical images before archiving them as PNGs with Aspose.Imaging in C#.
 * 5. When you are creating thumbnail previews of BMP graphics and need a quick Gaussian blur effect before saving them as PNGs for faster loading.
 */
