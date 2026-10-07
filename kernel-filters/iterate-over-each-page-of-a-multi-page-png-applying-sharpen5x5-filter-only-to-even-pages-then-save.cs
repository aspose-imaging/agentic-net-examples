// HOW-TO: Apply Sharpen5x5 Filter to Even Pages of Multi‑Page PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Apply filter to even-numbered pages (2,4,...) -> index i where (i + 1) % 2 == 0
                        if ((i + 1) % 2 == 0)
                        {
                            Image page = multipage.Pages[i];
                            if (page is RasterImage raster)
                            {
                                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen5x5));
                            }
                        }
                    }

                    PngOptions options = new PngOptions();
                    image.Save(outputPath, options);
                }
                else
                {
                    Console.Error.WriteLine("Input image is not a multipage PNG.");
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
 * 1. When you need to enhance the visual clarity of every second frame in a multi‑page PNG generated from scanned documents.
 * 2. When preparing a multi‑page PNG sprite sheet where only the even layers require sharpening for better UI rendering.
 * 3. When processing a PDF‑to‑PNG conversion where alternate pages contain low‑resolution graphics that must be sharpened before publishing.
 * 4. When creating a multi‑page PNG animation and want to apply a stronger edge definition to the even‑numbered frames to emphasize motion.
 * 5. When automating batch image cleanup and must selectively sharpen even pages of a multi‑page PNG without affecting the odd pages.
 */
