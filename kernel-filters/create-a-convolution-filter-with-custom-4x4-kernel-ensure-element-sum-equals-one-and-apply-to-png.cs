// HOW-TO: Apply Custom 4x4 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        kernel[i, j] = 1.0 / 16.0;
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to smooth a PNG image by averaging neighboring pixels using a custom 4x4 kernel with Aspose.Imaging for .NET.
 * 2. When you want to implement a simple blur effect on raster graphics before further processing or analysis in a C# application.
 * 3. When you must ensure the convolution kernel sums to one to preserve overall image brightness while applying a filter to a PNG file.
 * 4. When you are building an automated pipeline that loads PNG files, applies a uniform blur, and saves the results to a specific output folder.
 * 5. When you need to replace built‑in filters with a user‑defined kernel for consistent image preprocessing across multiple PNG assets.
 */
