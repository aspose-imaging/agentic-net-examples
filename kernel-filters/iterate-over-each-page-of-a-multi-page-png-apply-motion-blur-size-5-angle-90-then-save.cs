// HOW-TO: Apply Motion Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    var processedPages = new List<RasterImage>();

                    foreach (var page in multipage.Pages)
                    {
                        var raster = (RasterImage)page;
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(5, 90)));
                        processedPages.Add(raster);
                    }

                    Image[] pagesArray = processedPages.Cast<Image>().ToArray();

                    using (Image result = Image.Create(pagesArray, true))
                    {
                        result.Save(outputPath, new PngOptions());
                    }

                    foreach (var raster in processedPages)
                    {
                        raster.Dispose();
                    }
                }
                else
                {
                    var raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(5, 90)));
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to add a vertical motion‑blur effect to every frame of an animated PNG using Aspose.Imaging in C# before publishing it online.
 * 2. When processing scanned multi‑page PNG documents and you want to simulate camera shake on each page for visual testing with Aspose.Imaging.
 * 3. When creating stylized slide decks where each PNG slide requires a consistent motion blur applied programmatically in C#.
 * 4. When batch‑processing PNG spritesheets and you must apply the same motion‑blur filter to each sprite layer using Aspose.Imaging.
 * 5. When generating preview images of multi‑page PNGs with a motion‑blur overlay to indicate loading or transition effects in a .NET application.
 */
