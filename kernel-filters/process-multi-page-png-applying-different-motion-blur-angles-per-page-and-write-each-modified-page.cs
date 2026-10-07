// HOW-TO: Apply Different Motion Blur Angles to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input_multi_page.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    double[] angles = { 0, 45, 90, 135 };
                    int kernelSize = 5;

                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        double angle = angles[i % angles.Length];
                        using (RasterImage page = (RasterImage)multipage.Pages[i])
                        {
                            double[,] kernel = ConvolutionFilter.GetBlurMotion(kernelSize, angle);
                            var filterOptions = new ConvolutionFilterOptions(kernel);
                            page.Filter(page.Bounds, filterOptions);

                            string outputPath = Path.Combine("output_pages", $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multi-page image.");
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
 * 1. When you need to add directional motion blur to every frame of a multi‑page PNG animation for visual effects.
 * 2. When you must extract each page of a multi‑page PNG and save them as separate files after applying unique blur angles.
 * 3. When creating a series of stylized thumbnails where each page receives a different blur direction to emphasize motion.
 * 4. When preprocessing scanned document pages stored in a single PNG by applying angle‑specific blur to reduce scanning artifacts.
 * 5. When generating test images for computer‑vision algorithms that require varied motion blur across multiple pages of the same PNG.
 */
