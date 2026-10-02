// HOW-TO: Apply Motion Blur Filter to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace ImagingNet
{
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

                using (var image = (PngImage)Image.Load(inputPath))
                {
                    var multi = image as IMultipageImage;
                    if (multi == null)
                    {
                        Console.Error.WriteLine("The input image is not a multipage PNG.");
                        return;
                    }

                    for (int i = 0; i < multi.PageCount; i++)
                    {
                        using (var page = (RasterImage)multi.Pages[i])
                        {
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(5, 225));
                            page.Filter(page.Bounds, filterOptions);

                            string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            var saveOptions = new PngOptions();
                            page.Save(outputPath, saveOptions);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a directional motion‑blur effect to every frame of a multi‑page PNG document before publishing it online.
 * 2. When you must process scanned multi‑page PNGs and apply a consistent blur to reduce noise while preserving page boundaries.
 * 3. When generating animated PNG sequences where each frame requires the same 5‑pixel, 225‑degree blur for visual consistency.
 * 4. When automating a workflow that extracts each page of a multi‑page PNG, applies a convolution filter, and saves the results as separate PNG files for downstream editing.
 * 5. When creating thumbnails of multi‑page PNGs with a subtle motion‑blur to convey motion in a gallery preview using Aspose.Imaging for .NET.
 */
