// HOW-TO: Apply Gaussian Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\blurred.png";

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
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        RasterImage page = (RasterImage)multipage.Pages[i];
                        page.Filter(page.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    }

                    var saveOptions = new ApngOptions();
                    image.Save(outputPath, saveOptions);
                }
                else
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to soften the visual details of every frame in an animated PNG before publishing it on a website.
 * 2. When you want to automatically apply a consistent blur effect to each page of a multi‑page scanned document saved as PNG for privacy redaction.
 * 3. When generating a blurred preview of a large APNG sprite sheet in a C# application to improve loading performance.
 * 4. When creating a batch process that adds Gaussian blur to both single‑page and multi‑page PNG files using Aspose.Imaging.
 * 5. When preparing PNG assets for a game UI where each animation frame must have a uniform blur radius applied programmatically.
 */
