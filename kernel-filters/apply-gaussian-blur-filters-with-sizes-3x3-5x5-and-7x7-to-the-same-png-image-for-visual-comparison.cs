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
            // Hardcoded input path
            string inputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output paths for each kernel size
            string outputPath3 = @"C:\Images\sample.GaussianBlur3x3.png";
            string outputPath5 = @"C:\Images\sample.GaussianBlur5x5.png";
            string outputPath7 = @"C:\Images\sample.GaussianBlur7x7.png";

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
 * 1. When a developer needs to generate preview thumbnails with varying softness for a PNG product catalog, they can apply 3x3, 5x5, and 7x7 Gaussian blur filters using Aspose.Imaging for .NET to compare visual impact.
 * 2. When building a photo‑editing web service in C#, the code can be used to create side‑by‑side blurred versions of a PNG upload so users can choose the appropriate blur strength before saving.
 * 3. When testing the performance of different Gaussian kernel sizes on PNG assets in a desktop application, a developer can run this snippet to benchmark rendering speed and image quality across 3x3, 5x5, and 7x7 filters.
 * 4. When preparing PNG graphics for a game UI where background elements need progressive softening, the code helps generate three pre‑blurred assets with distinct sigma values for easy swapping at runtime.
 * 5. When documenting image‑processing pipelines, a developer can use this example to demonstrate how Aspose.Imaging’s GaussianBlurFilterOptions manipulate PNG files in C# and produce comparable output files for training machine‑learning models that require varied blur levels.
 */