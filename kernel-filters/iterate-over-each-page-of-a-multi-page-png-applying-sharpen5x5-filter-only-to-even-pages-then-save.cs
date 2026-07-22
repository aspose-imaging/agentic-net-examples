using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        if (i % 2 == 0) // even pages (0‑based index)
                        {
                            Image page = multipage.Pages[i];
                            if (page is RasterImage raster)
                            {
                                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                            }
                        }
                    }
                }

                image.Save(outputPath);
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
 * 1. When a developer needs to enhance the visual clarity of every second frame in a multi‑page PNG animation by applying a Sharpen5x5 filter before publishing it online.
 * 2. When processing scanned document bundles saved as a multi‑page PNG and the even‑numbered pages contain low‑contrast diagrams that must be sharpened using Aspose.Imaging in a C# application.
 * 3. When generating a printable PDF from a multi‑page PNG where the even pages are product photos that require a 5×5 sharpening kernel to meet print quality standards.
 * 4. When building a C# batch‑processing tool that automatically improves the sharpness of even pages in multi‑page PNG spritesheets for a game asset pipeline.
 * 5. When creating a server‑side image service that receives multi‑page PNGs and must selectively sharpen only the even pages to reduce file size while preserving detail for downstream AI analysis.
 */