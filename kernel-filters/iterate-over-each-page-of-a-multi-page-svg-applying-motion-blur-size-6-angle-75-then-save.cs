using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    string tempPath = Path.Combine(outputDir, $"page_{i}.png");
                    string finalPath = Path.Combine(outputDir, $"page_{i}_blur.png");

                    // Ensure directories exist before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(finalPath));

                    // Export single page to PNG
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                    image.Save(tempPath, pngOptions);

                    // Load the exported page as raster image
                    using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                    {
                        // Apply motion blur filter (size 6, smooth 1.0, angle 75)
                        raster.Filter(raster.Bounds, new MotionWienerFilterOptions(6, 1.0, 75.0));

                        // Save the filtered image
                        raster.Save(finalPath);
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
 * 1. A developer can use this C# Aspose.Imaging code to generate PNG thumbnails of each page in a multi‑page SVG and add a 6‑pixel motion blur at a 75° angle to create a dynamic preview for a web gallery.
 * 2. This snippet is useful when converting vector diagrams from a multi‑page SVG into individual PNG slides and applying a motion‑blur filter to give a stylized transition effect in a presentation application.
 * 3. Game developers may extract each frame of a multi‑page SVG sprite sheet, save them as PNG raster images, and apply a 6‑size motion blur at 75° to simulate fast movement in the UI.
 * 4. When preparing print‑ready assets, a designer can run this C# code to rasterize each SVG page to PNG and automatically apply a motion blur, emphasizing motion‑related sections of a brochure.
 * 5. An automated reporting pipeline can iterate over a multi‑page SVG, export each page as a PNG, and use Aspose.Imaging’s MotionWienerFilterOptions to add a 75° motion blur, delivering visually enhanced charts for dashboards.
 */