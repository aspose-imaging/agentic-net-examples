// HOW-TO: How To Sharpen A PNG And Compare Histograms In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                var beforeHistogram = new Dictionary<int, int>();
                foreach (int pixel in beforePixels)
                {
                    if (beforeHistogram.ContainsKey(pixel))
                        beforeHistogram[pixel]++;
                    else
                        beforeHistogram[pixel] = 1;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3);
                raster.Filter(raster.Bounds, filterOptions);

                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                var afterHistogram = new Dictionary<int, int>();
                foreach (int pixel in afterPixels)
                {
                    if (afterHistogram.ContainsKey(pixel))
                        afterHistogram[pixel]++;
                    else
                        afterHistogram[pixel] = 1;
                }

                Console.WriteLine("Histogram before processing:");
                foreach (var kvp in beforeHistogram)
                {
                    Console.WriteLine($"Pixel 0x{kvp.Key:X8}: {kvp.Value}");
                }

                Console.WriteLine("\nHistogram after processing:");
                foreach (var kvp in afterHistogram)
                {
                    Console.WriteLine($"Pixel 0x{kvp.Key:X8}: {kvp.Value}");
                }

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
 * 1. When you need to enhance the sharpness of a PNG image before displaying it in a web application and want to verify the effect by analyzing pixel distribution.
 * 2. When you are building an automated image‑processing pipeline that applies a 3×3 sharpen filter to PNG files and logs before‑and‑after histograms for quality control.
 * 3. When you want to compare the color composition of an original PNG with its sharpened version to ensure no unwanted color shifts occur.
 * 4. When you are developing a desktop tool that lets users preview the impact of sharpening on PNG graphics and see statistical changes in pixel frequencies.
 * 5. When you need to programmatically generate a sharpened PNG and store histogram data for later image‑analysis or machine‑learning tasks.
 */
