// HOW-TO: Batch Convert SVG to PNG with Motion Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = svgImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(8, 1.0, 60.0));
                            raster.Save(outputPath);
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
 * 1. When you need to generate blurred PNG thumbnails from a collection of SVG icons for a web gallery.
 * 2. When you want to preprocess vector graphics for a mobile app by rasterizing them to PNG and adding a motion‑blur effect to simulate movement.
 * 3. When an e‑commerce platform requires product illustrations in PNG format with a consistent blur style for promotional banners.
 * 4. When automating the creation of background images for video games, converting SVG assets to PNG and applying a 60‑degree motion blur of size 8.
 * 5. When preparing print‑ready assets where SVG logos must be rasterized to PNG with a subtle motion blur to match a brand’s visual guidelines.
 */
