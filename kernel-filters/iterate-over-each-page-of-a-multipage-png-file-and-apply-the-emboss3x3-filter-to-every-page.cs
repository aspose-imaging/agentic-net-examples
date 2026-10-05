// HOW-TO: Apply Emboss Filter to Every Page of a Multipage PNG in C# (Aspose.Imaging for .NET)
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

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    foreach (var page in multipage.Pages)
                    {
                        if (page is RasterImage raster)
                        {
                            var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                            var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, options);
                        }
                    }
                }
                else if (image is RasterImage raster)
                {
                    var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                    var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, options);
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
 * 1. When you need to add a 3‑D embossed effect to each frame of a multi‑page PNG before publishing it online.
 * 2. When you want to preprocess scanned document pages stored as a PNG stack by applying an emboss filter to enhance edge contrast for OCR preprocessing.
 * 3. When generating stylized thumbnails for every page of a PNG animation and require a consistent emboss effect across all frames.
 * 4. When converting a single‑page PNG to an embossed version using the same code path that also supports multipage files, simplifying maintenance.
 * 5. When automating a batch workflow that reads PNG files, applies a convolution emboss filter, and saves the result with Aspose.Imaging in a .NET application.
 */
