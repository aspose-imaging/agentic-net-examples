// HOW-TO: Apply Custom Convolution Kernel with Emboss Fallback to PNG in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] customKernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                bool useFallback = false;

                try
                {
                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, convOptions);
                }
                catch (Exception)
                {
                    useFallback = true;
                }

                if (useFallback)
                {
                    var fallbackOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, fallbackOptions);
                }

                var pngOptions = new PngOptions();
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
 * 1. When you need to sharpen a PNG image using a custom convolution kernel but want a safe fallback if the kernel is invalid.
 * 2. When processing user‑uploaded PNG files and must ensure the filter operation never crashes the application.
 * 3. When you want to automatically apply an emboss effect to images when a custom filter cannot be applied.
 * 4. When building a batch image‑processing pipeline that validates kernels at runtime and substitutes a default filter.
 * 5. When you need to save the filtered result back to PNG format while handling missing files and directory creation.
 */
