// HOW-TO: Apply Sharpen 5x5 Filter to Even Pages of Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multiPage = image as IMultipageImage;
                if (multiPage != null && multiPage.Pages != null)
                {
                    // Iterate over pages
                    for (int i = 0; i < multiPage.Pages.Length; i++)
                    {
                        // Apply filter only to even page numbers (2,4,...) -> zero‑based odd indices
                        if (i % 2 == 1)
                        {
                            RasterImage raster = multiPage.Pages[i] as RasterImage;
                            if (raster != null)
                            {
                                // Sharpen 5x5 filter (size 5, sigma 4.0)
                                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                            }
                        }
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image with default PNG options
                PngOptions saveOptions = new PngOptions();
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
 * 1. When you need to enhance the visual clarity of every second frame in a multi‑page PNG generated from scanned documents.
 * 2. When processing animated PNGs where only the even‑numbered frames should be sharpened to improve detail without affecting odd frames.
 * 3. When preparing a multi‑page PNG for printing and want to apply a stronger edge definition to alternate pages to highlight graphics.
 * 4. When building a C# image‑processing pipeline that conditionally applies a 5×5 sharpening filter to specific pages of a PNG sprite sheet.
 * 5. When optimizing a multi‑page PNG archive and need to selectively sharpen even pages to balance quality and file size.
 */
