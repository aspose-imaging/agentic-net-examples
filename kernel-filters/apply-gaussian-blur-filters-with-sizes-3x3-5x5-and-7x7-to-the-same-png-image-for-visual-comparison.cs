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
            string inputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output paths for each kernel size
            string outputPath3 = @"C:\Images\sample.GaussianBlur_3x3.png";
            string outputPath5 = @"C:\Images\sample.GaussianBlur_5x5.png";
            string outputPath7 = @"C:\Images\sample.GaussianBlur_7x7.png";

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
 * 1. When a developer needs to generate preview thumbnails with varying blur strengths to let users compare the visual impact of 3x3, 5x5, and 7x7 Gaussian blur on a PNG asset in a C# web application.
 * 2. When an image‑processing pipeline must create side‑by‑side before‑and‑after samples for a UI that demonstrates how different kernel sizes affect noise reduction in raster PNG images using Aspose.Imaging for .NET.
 * 3. When a QA engineer wants to automate regression testing of the GaussianBlurFilterOptions class by saving the same source PNG with 3x3, 5x5, and 7x7 kernels and comparing the output files for consistency.
 * 4. When a desktop publishing tool needs to offer designers quick visual feedback on how various blur radii (sigma 1.0, 2.0, 3.0) change the appearance of logos stored as PNG files, using C# and Aspose.Imaging.
 * 5. When a machine‑learning dataset is being prepared and the developer must augment a PNG image with multiple levels of Gaussian blur to increase training diversity, saving each version with a distinct file name.
 */