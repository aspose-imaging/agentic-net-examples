// HOW-TO: Apply Motion Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output\\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports multiple pages, process each page
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Retrieve the page as an Image
                        Image page = multipageImage.Pages[i];

                        // Apply motion blur to raster pages
                        if (page is RasterImage rasterPage)
                        {
                            rasterPage.Filter(rasterPage.Bounds, new MotionWienerFilterOptions(5, 1.0, 90.0));
                        }
                    }
                }
                else
                {
                    // Single‑page image fallback
                    if (image is RasterImage raster)
                    {
                        raster.Filter(raster.Bounds, new MotionWienerFilterOptions(5, 1.0, 90.0));
                    }
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to add a vertical motion‑blur effect to every frame of an animated PNG before publishing it.
 * 2. When processing scanned documents saved as a multi‑page PNG and you want to simulate camera shake on each page.
 * 3. When creating a slideshow where each slide is a PNG page and you need a consistent blur filter applied automatically.
 * 4. When preparing multi‑page PNG assets for a game and you must apply the same motion blur parameters to all layers.
 * 5. When batch‑editing a multi‑page PNG archive to improve visual consistency by applying a 5‑pixel, 90‑degree blur across all pages.
 */
