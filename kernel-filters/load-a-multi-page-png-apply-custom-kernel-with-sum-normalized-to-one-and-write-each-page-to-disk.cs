// HOW-TO: Apply Averaging Convolution Filter to Each Page of Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    int pageIndex = 0;
                    foreach (Image page in multipage.Pages)
                    {
                        using (RasterImage raster = (RasterImage)page)
                        {
                            double[,] kernel = new double[,]
                            {
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                                { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                            };
                            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                            string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                            string outputPathDir = Path.GetDirectoryName(outputPath);
                            if (!string.IsNullOrWhiteSpace(outputPathDir))
                            {
                                Directory.CreateDirectory(outputPathDir);
                            }

                            var options = new PngOptions
                            {
                                Source = new FileCreateSource(outputPath, false)
                            };
                            raster.Save(outputPath, options);
                        }
                        pageIndex++;
                    }
                }
                else
                {
                    using (RasterImage raster = (RasterImage)image)
                    {
                        double[,] kernel = new double[,]
                        {
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                        };
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                        string outputPath = Path.Combine(outputDir, "page_0.png");
                        string outputPathDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrWhiteSpace(outputPathDir))
                        {
                            Directory.CreateDirectory(outputPathDir);
                        }

                        var options = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, options);
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
 * 1. When you need to reduce noise on every frame of a multi‑page PNG before performing image analysis.
 * 2. When you want to generate separate blurred thumbnails from each page of a multi‑page PNG for a web gallery.
 * 3. When you must preprocess each layer of a scanned document stored as a multi‑page PNG to improve OCR accuracy.
 * 4. When you are creating a batch of uniformly smoothed images from a multi‑page PNG for machine‑learning training data.
 * 5. When you need to export each page of a multi‑page PNG after applying a custom convolution kernel to ensure consistent visual effects across all pages.
 */
