// HOW-TO: Apply Emboss 3x3 Filter to PNG While Preserving Color Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var options = new PngOptions();

                raster.Filter(raster.Bounds,
                    new ConvolutionFilterOptions(
                        ConvolutionFilter.Emboss3x3));

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
 * 1. When you need to add a subtle embossed effect to product photos stored as PNGs without losing their embedded ICC color profile.
 * 2. When generating stylized thumbnails for a web gallery and must keep the original color accuracy using C# and Aspose.Imaging.
 * 3. When processing scanned documents in PNG format and want to highlight edges with an emboss filter while preserving the source color calibration.
 * 4. When creating custom UI icons that require a 3‑x‑3 emboss effect and must retain the original PNG transparency and profile for consistent rendering across devices.
 * 5. When automating batch image enhancement in a .NET application and need to apply a convolution emboss filter to each PNG while ensuring the embedded color profile remains intact.
 */
