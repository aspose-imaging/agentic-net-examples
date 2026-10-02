// HOW-TO: Sharpen a PNG Image Using Aspose.Imaging Convolution Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output/sharpened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen5x5));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to enhance the clarity of a product photo stored as PNG before publishing it on a website.
 * 2. When an automated batch job must apply a 5×5 sharpening filter to template images for a printing workflow.
 * 3. When a desktop application requires real‑time sharpening of user‑uploaded PNG graphics while ensuring memory is released promptly.
 * 4. When you generate sharpened thumbnails from PNG assets for a mobile app and want to use Aspose.Imaging’s convolution filter.
 * 5. When a server‑side service processes PNG templates, sharpens them for better OCR accuracy, and must clean up image resources to avoid leaks.
 */
