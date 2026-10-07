// HOW-TO: Apply Emboss3x3 Filter To Barcode PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "barcode.png";
            string outputPath = "filtered_barcode.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to preprocess scanned barcode PNG files with an emboss effect to evaluate how the filter impacts detection accuracy before decoding.
 * 2. When integrating Aspose.Imaging in a C# application to automatically apply a 3x3 emboss convolution to barcode images for visual quality testing.
 * 3. When creating a batch workflow that reads barcode images, applies a convolution filter, and saves the result as PNG for further analysis.
 * 4. When debugging barcode recognition algorithms by comparing raw and embossed images to understand filter‑induced artifacts.
 * 5. When building a proof‑of‑concept that demonstrates how to use Aspose.Imaging’s Filter method with ConvolutionFilterOptions on raster images in .NET.
 */
