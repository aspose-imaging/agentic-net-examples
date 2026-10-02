// HOW-TO: Apply Motion Blur to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(7, 30)));
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
 * 1. When you need to add a realistic motion blur effect to a PNG product photo before publishing it on a website.
 * 2. When generating game asset frames where each PNG image must have a consistent 30‑degree motion blur of size 7.
 * 3. When preparing a marketing banner PNG template and want to soften edges with a directional motion blur to match the brand’s visual style.
 * 4. When processing user‑uploaded PNG images on a server and applying a motion blur filter to ensure visual consistency across all uploads.
 * 5. When creating a series of PNG slides for a presentation and require the same motion blur applied automatically via C# code.
 */
