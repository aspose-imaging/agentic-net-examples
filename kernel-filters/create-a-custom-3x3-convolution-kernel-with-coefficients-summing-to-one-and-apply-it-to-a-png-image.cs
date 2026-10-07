// HOW-TO: Apply Custom 3x3 Convolution Kernel to PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions
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
 * 1. When you need to smooth or blur a PNG photo in a .NET application using Aspose.Imaging.
 * 2. When you want to implement a custom averaging filter for noise reduction on raster images before further analysis.
 * 3. When you must process large batches of PNG files with a consistent convolution kernel to prepare them for machine‑learning preprocessing.
 * 4. When you are building an image‑editing tool that lets users apply custom 3×3 filters to uploaded PNG graphics.
 * 5. When you need to ensure the filtered image is saved with lossless PNG compression while preserving the original dimensions.
 */
