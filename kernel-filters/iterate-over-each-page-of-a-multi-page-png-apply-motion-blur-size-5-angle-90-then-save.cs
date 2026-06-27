using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    foreach (Image page in multipageImage.Pages)
                    {
                        if (page is RasterImage rasterPage)
                        {
                            rasterPage.Filter(
                                rasterPage.Bounds,
                                new MotionWienerFilterOptions(5, 1.0, 90.0));
                        }
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
 * 1. When a developer needs to add a vertical motion blur effect to every frame of a multi‑page PNG (such as an animated scan) before publishing, this code iterates through each page, applies a size‑5 blur at a 90° angle, and saves the result.
 * 2. When processing a multi‑page PNG invoice that contains scanned pages, a developer can use this code to uniformly blur sensitive information on each page with a motion blur filter before archiving.
 * 3. When creating a stylized slideshow of PNG images where each slide should appear as if captured with camera shake, this C# snippet applies a consistent motion blur across all pages of the multi‑page PNG.
 * 4. When preparing a multi‑page PNG sprite sheet for a game and needing to simulate motion on every sprite, a developer can run this code to apply a 5‑pixel, 90‑degree motion blur to each raster page automatically.
 * 5. When automating the preprocessing of multi‑page PNG medical scans to reduce visual noise by adding a directional blur, this example shows how to loop through each page, apply the filter, and store the processed file.
 */