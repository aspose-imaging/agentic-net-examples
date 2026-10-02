// HOW-TO: Apply Emboss 3x3 Filter to PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.png";
            string outputPath = "output/embossed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to add a subtle 3‑D embossed effect to product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to preprocess scanned PNG documents to highlight edges for better visual inspection in a desktop C# application.
 * 3. When you are generating stylized thumbnails for an image gallery and require an emboss filter to make the PNG images stand out.
 * 4. When you need to apply a convolution filter to a PNG sprite sheet in a game‑development pipeline using Aspose.Imaging for C#.
 * 5. When you are creating a batch script that automatically enhances PNG graphics with an emboss effect for printing marketing brochures.
 */
