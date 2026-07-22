using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath3 = @"C:\temp\sample.GaussianBlur3x3.png";
            string outputPath5 = @"C:\temp\sample.GaussianBlur5x5.png";
            string outputPath7 = @"C:\temp\sample.GaussianBlur7x7.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath7));

            // Apply 3x3 Gaussian blur (size=3, sigma=1.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(3, 1.0));
                rasterImage.Save(outputPath3);
            }

            // Apply 5x5 Gaussian blur (size=5, sigma=2.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                rasterImage.Save(outputPath5);
            }

            // Apply 7x7 Gaussian blur (size=7, sigma=3.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(7, 3.0));
                rasterImage.Save(outputPath7);
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
 * 1. When a developer needs to compare the visual impact of different Gaussian blur kernel sizes (3x3, 5x5, 7x7) on a PNG asset for UI design decisions.
 * 2. When an automated image‑processing pipeline must generate softened previews of a product photo in multiple blur strengths for a web catalog.
 * 3. When a QA engineer wants to validate that the Aspose.Imaging GaussianBlurFilterOptions produce consistent results across various kernel sizes in a C# unit test.
 * 4. When a desktop application requires on‑the‑fly generation of blurred background layers from a source PNG to improve readability of overlaid text.
 * 5. When a batch script processes user‑uploaded PNG files and stores three versions with increasing blur for progressive loading or artistic effects.
 */