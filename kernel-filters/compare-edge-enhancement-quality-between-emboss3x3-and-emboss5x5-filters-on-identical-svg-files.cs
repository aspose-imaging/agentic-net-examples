// HOW-TO: Compare Emboss 3x3 vs 5x5 Filter Quality on SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath3x3 = @"C:\Images\sample_emboss3x3.png";
        string outputPath5x5 = @"C:\Images\sample_emboss5x5.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // -----------------------------------------------------------------
            // Process with 3x3 Emboss kernel
            // -----------------------------------------------------------------
            using (Image image = Image.Load(inputPath))
            {
                // Cast to raster image for filtering
                RasterImage raster = (RasterImage)image;

                // Apply the 3x3 emboss convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));

                // Save the filtered image
                raster.Save(outputPath3x3);
            }

            // -----------------------------------------------------------------
            // Process with 5x5 Emboss kernel
            // -----------------------------------------------------------------
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the 5x5 emboss convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));
                raster.Save(outputPath5x5);
            }
        }
        catch (Exception ex)
        {
            // Unified error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to evaluate which emboss kernel (3x3 or 5x5) produces sharper edge details for vector graphics converted to raster PNGs.
 * 2. When an application needs to generate two versions of the same SVG with different emboss effects for side‑by‑side visual comparison.
 * 3. When a UI designer wants to preview how a logo will look with light‑direction embossing before choosing a filter for branding assets.
 * 4. When an automated testing suite must verify that the Aspose.Imaging convolution filters produce consistent results across different kernel sizes.
 * 5. When a batch‑processing tool must convert SVG icons to embossed PNGs with both small and large kernels to support high‑resolution and low‑resolution displays.
 */
