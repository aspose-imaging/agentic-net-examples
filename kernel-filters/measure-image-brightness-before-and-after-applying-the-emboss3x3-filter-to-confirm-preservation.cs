// HOW-TO: Measure Image Brightness Before and After Emboss Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Measure brightness before filter
                int[] pixelsBefore = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double avgBefore = pixelsBefore
                    .Select(p => ((p >> 16) & 0xFF) + ((p >> 8) & 0xFF) + (p & 0xFF))
                    .Average() / 3.0;

                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Measure brightness after filter
                int[] pixelsAfter = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double avgAfter = pixelsAfter
                    .Select(p => ((p >> 16) & 0xFF) + ((p >> 8) & 0xFF) + (p & 0xFF))
                    .Average() / 3.0;

                Console.WriteLine($"Average brightness before: {avgBefore:F2}");
                Console.WriteLine($"Average brightness after: {avgAfter:F2}");

                // Save the filtered image
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
 * 1. When you need to verify that applying an emboss convolution filter does not unintentionally darken or brighten a PNG image in a .NET application.
 * 2. When you want to log the average RGB brightness of a raster image before and after processing for quality‑control reporting.
 * 3. When building an automated image‑processing pipeline that must compare pre‑ and post‑filter brightness to maintain visual consistency across assets.
 * 4. When debugging a photo‑editing feature that uses Aspose.Imaging’s Emboss3x3 filter and you need numeric evidence of its impact on image luminance.
 * 5. When generating side‑by‑side comparisons of original and filtered images and need the brightness values to annotate the results in a C# console tool.
 */
