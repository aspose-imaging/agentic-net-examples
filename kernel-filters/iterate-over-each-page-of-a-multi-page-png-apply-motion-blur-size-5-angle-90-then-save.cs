using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.IMultipageImage multipageImage = image as Aspose.Imaging.IMultipageImage;
                int pageCount = multipageImage != null ? multipageImage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    Aspose.Imaging.RasterImage page;
                    if (multipageImage != null)
                    {
                        page = (Aspose.Imaging.RasterImage)multipageImage.Pages[i];
                    }
                    else
                    {
                        page = (Aspose.Imaging.RasterImage)image;
                    }

                    using (page)
                    {
                        page.Filter(page.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 90.0));

                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions saveOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
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

/*
 * Real-World Use Cases:
 * 1. When generating a series of scanned document pages that need a vertical motion‑blur effect to simulate a scanning artifact, a developer can loop through each PNG page, apply a 5‑pixel blur at 90°, and save the results.
 * 2. When preparing multi‑page PNG sprites for a game and wanting to create a motion‑blur overlay for a scrolling animation, the code can process each frame, blur vertically, and export individual PNG files.
 * 3. When cleaning up multi‑page medical imaging PNGs by adding a subtle vertical blur to reduce high‑frequency noise before archiving, the developer can iterate pages, apply the filter, and store them in an output folder.
 * 4. When converting a multi‑page PNG invoice into separate pages with a consistent vertical blur to hide sensitive information while preserving layout, the code iterates each page, blurs at angle 90°, and saves each page.
 * 5. When building an automated batch job that adds a vertical motion‑blur watermark effect to every page of a multi‑page PNG advertisement before publishing to a web portal, the developer can use this loop to process and save each page.
 */