// HOW-TO: Apply Custom Normalized 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[3, 3];
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] = (x == 1 && y == 1) ? 0.6 : 0.1;
                    }
                }

                double sum = 0;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        sum += kernel[y, x];
                    }
                }

                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                saveOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to smooth a PNG image while preserving its central pixel intensity using a custom kernel in a C# application.
 * 2. When you want to implement a lightweight blur effect for UI thumbnails by applying a normalized 3x3 convolution filter with Aspose.Imaging.
 * 3. When you must preprocess scanned PNG graphics to reduce noise before performing OCR or pattern recognition in .NET.
 * 4. When you are building an automated image pipeline that requires consistent edge weighting and center emphasis for PNG assets.
 * 5. When you need to replace a built‑in blur filter with a manually defined kernel to achieve a specific visual style in a C# imaging project.
 */
