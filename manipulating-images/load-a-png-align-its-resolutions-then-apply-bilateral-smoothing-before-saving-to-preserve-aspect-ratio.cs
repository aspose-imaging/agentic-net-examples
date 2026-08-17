// HOW-TO: Set PNG DPI and Apply Bilateral Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Align horizontal and vertical resolutions
                if (image is PngImage pngImage)
                {
                    double targetResolution = 96.0; // Desired DPI
                    pngImage.SetResolution(targetResolution, targetResolution);
                }

                // Apply bilateral smoothing filter
                if (image is RasterImage rasterImage)
                {
                    var filterOptions = new BilateralSmoothingFilterOptions(5); // Kernel size 5
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);
                }

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to standardize the DPI of PNG assets for consistent printing or screen display while reducing noise with a bilateral smoothing filter.
 * 2. When preparing product photos for an e‑commerce catalog, you can align resolutions and smooth edges without distorting the image’s aspect ratio.
 * 3. When converting scanned PNG documents to a uniform 96 DPI resolution before archival, applying bilateral smoothing helps remove scanning artifacts.
 * 4. When generating thumbnails for a web gallery, setting the PNG resolution and applying bilateral smoothing ensures sharp yet noise‑free previews.
 * 5. When integrating PNG images into a CAD workflow, you can enforce a common DPI and smooth pixel variations to improve visual quality in technical drawings.
 */
