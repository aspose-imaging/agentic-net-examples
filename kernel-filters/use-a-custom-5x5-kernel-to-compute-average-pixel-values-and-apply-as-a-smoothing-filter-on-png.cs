// HOW-TO: Apply 5x5 Average Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
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
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
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
 * 1. When you need to reduce noise in a PNG image by smoothing it with a uniform blur in a C# application.
 * 2. When you want to preprocess scanned documents before OCR by applying a box blur to even out pixel variations.
 * 3. When you are building a photo‑editing tool that offers a simple blur effect for PNG files using Aspose.Imaging.
 * 4. When you need to create a consistent visual style across a series of PNG assets by applying the same averaging filter programmatically.
 * 5. When you are optimizing PNG graphics for web display and want to soften sharp edges without changing the file format.
 */
