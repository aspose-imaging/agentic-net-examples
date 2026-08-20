// HOW-TO: Apply Multiple Gaussian Blur Sizes to a PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory and file paths
            string outputDir = "output";
            string outputPath3 = Path.Combine(outputDir, "output_3x3.png");
            string outputPath5 = Path.Combine(outputDir, "output_5x5.png");
            string outputPath7 = Path.Combine(outputDir, "output_7x7.png");

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath7));

            // Apply 3x3 Gaussian blur (radius=1, sigma=1.0)
            using (Image image3 = Image.Load(inputPath))
            {
                RasterImage raster3 = (RasterImage)image3;
                raster3.Filter(raster3.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(1, 1.0));
                raster3.Save(outputPath3);
            }

            // Apply 5x5 Gaussian blur (radius=2, sigma=2.0)
            using (Image image5 = Image.Load(inputPath))
            {
                RasterImage raster5 = (RasterImage)image5;
                raster5.Filter(raster5.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 2.0));
                raster5.Save(outputPath5);
            }

            // Apply 7x7 Gaussian blur (radius=3, sigma=3.0)
            using (Image image7 = Image.Load(inputPath))
            {
                RasterImage raster7 = (RasterImage)image7;
                raster7.Filter(raster7.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(3, 3.0));
                raster7.Save(outputPath7);
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
 * 1. When you need to generate preview thumbnails with varying blur levels to compare visual effects for UI design.
 * 2. When creating before‑and‑after samples for a photo‑editing tutorial that demonstrates how different Gaussian kernel sizes affect image softness.
 * 3. When preprocessing PNG assets for a game to test which blur radius provides the best performance‑to‑quality balance.
 * 4. When automating quality‑control checks that require side‑by‑side comparison of 3x3, 5x5, and 7x7 Gaussian blurs on the same image.
 * 5. When building a batch‑processing tool that applies multiple blur filters to the same source file for artistic or anonymization purposes.
 */
