// HOW-TO: Apply Varying Motion Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No pages found in the image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    using (RasterImage page = (RasterImage)multipage.Pages[i])
                    {
                        double angle = i * 30.0; // Varying angle per page
                        var filterOptions = new MotionWienerFilterOptions(10, 1.0, angle);
                        page.Filter(page.Bounds, filterOptions);

                        string outputPath = $"output\\page{i + 1}.png";
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a series of preview images from a multi‑page PNG, applying a different motion‑blur direction to each page for an animated effect.
 * 2. When a document‑processing pipeline must add a custom blur angle to every layer of a scanned multi‑page PNG before saving the pages as separate PNG files.
 * 3. When creating scientific visualizations that simulate motion across successive slices of a PNG stack by incrementally increasing the blur angle on each slice.
 * 4. When producing stylized thumbnails for a multi‑page PNG catalog, giving each thumbnail a unique motion‑blur angle to emphasize different product perspectives.
 * 5. When automating quality‑control tests that compare original and motion‑blurred versions of each page in a multi‑page PNG using C# and Aspose.Imaging.
 */
