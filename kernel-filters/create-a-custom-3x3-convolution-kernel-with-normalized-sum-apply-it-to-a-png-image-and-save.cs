// HOW-TO: Apply Custom Normalized 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 1.0 / 16, 2.0 / 16, 1.0 / 16 },
                    { 2.0 / 16, 4.0 / 16, 2.0 / 16 },
                    { 1.0 / 16, 2.0 / 16, 1.0 / 16 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to smooth a PNG photo using a Gaussian blur implemented with a normalized 3x3 convolution kernel in C#.
 * 2. When you want to reduce image noise in a PNG before further analysis by applying a custom filter with Aspose.Imaging.
 * 3. When you must apply a consistent blur effect across all frames of a PNG sprite sheet using a programmable kernel.
 * 4. When you are building a .NET service that automatically preprocesses uploaded PNGs with a standard convolution filter for machine‑learning pipelines.
 * 5. When you need to demonstrate how to load, filter, and save PNG images using Aspose.Imaging’s RasterImage class in a tutorial or proof‑of‑concept project.
 */
