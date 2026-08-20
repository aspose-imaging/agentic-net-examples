// HOW-TO: Apply Emboss3x3 Filter to All Pages of a Multipage PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
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
                if (image is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        var page = multipage.Pages[i];
                        using (RasterImage raster = (RasterImage)page)
                        {
                            raster.Filter(
                                raster.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                        }
                    }
                }

                var saveOptions = new PngOptions();
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
 * 1. When you need to add a 3×3 emboss effect to every frame of an animated PNG before publishing it online.
 * 2. When you want to preprocess each page of a multi‑page scanned PNG document to highlight edges for OCR or visual inspection.
 * 3. When you are generating stylized thumbnails for each layer of a PNG sprite sheet and require a consistent emboss look.
 * 4. When you must batch‑apply a convolution filter to all pages of a multi‑page PNG in a .NET service that prepares images for a printing workflow.
 * 5. When you are building a C# desktop application that lets users apply artistic effects to each page of a multi‑page PNG file without losing the original file structure.
 */
