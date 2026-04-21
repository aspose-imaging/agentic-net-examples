using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output_sharpened.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Load original pixels and compute histogram
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                var beforeHist = new Dictionary<int, int>();
                foreach (int pixel in beforePixels)
                {
                    if (beforeHist.ContainsKey(pixel))
                        beforeHist[pixel]++;
                    else
                        beforeHist[pixel] = 1;
                }

                // Apply Sharpen filter (default SharpenFilterOptions)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                // Save the processed image
                raster.Save(outputPath, new PngOptions());

                // Load processed pixels and compute histogram
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                var afterHist = new Dictionary<int, int>();
                foreach (int pixel in afterPixels)
                {
                    if (afterHist.ContainsKey(pixel))
                        afterHist[pixel]++;
                    else
                        afterHist[pixel] = 1;
                }

                // Output histograms
                Console.WriteLine("Histogram before filter:");
                foreach (var kvp in beforeHist)
                {
                    Console.WriteLine($"{kvp.Key:X8}: {kvp.Value}");
                }

                Console.WriteLine("Histogram after filter:");
                foreach (var kvp in afterHist)
                {
                    Console.WriteLine($"{kvp.Key:X8}: {kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}