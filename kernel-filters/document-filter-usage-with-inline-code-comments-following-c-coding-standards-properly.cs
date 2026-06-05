using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingFilterDemo
{
    /// <summary>
    /// Demonstrates applying a sharpen filter to a raster image using Aspose.Imaging.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.SharpenFilter.png";

            try
            {
                // Verify that the input file exists; report and exit if it does not.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists before attempting to save.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image from disk.
                using (Image image = Image.Load(inputPath))
                {
                    // Cast the generic Image to a RasterImage to access filtering capabilities.
                    RasterImage rasterImage = (RasterImage)image;

                    // Create sharpen filter options with a kernel size of 5 and sigma of 4.0.
                    var sharpenOptions = new SharpenFilterOptions(5, 4.0);

                    // Apply the sharpen filter to the entire image bounds.
                    rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                    // Save the processed image to the specified output path.
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any unexpected errors without crashing the application.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically enhance the visual clarity of PNG screenshots by applying a 5‑pixel sharpen filter with sigma 4.0 before publishing them to a website.
 * 2. When an image‑processing pipeline must batch‑process raster images stored on disk, verifying file existence and creating output folders, to ensure consistent sharpening across all assets.
 * 3. When a C# application integrates Aspose.Imaging to improve the detail of scanned documents (e.g., PDFs converted to PNG) by applying a sharpen filter to the entire image bounds.
 * 4. When a Windows service has to load a raster image, apply a custom kernel‑based sharpening operation, and save the result with a descriptive filename for later quality‑control review.
 * 5. When troubleshooting image‑quality issues, a developer wants to quickly test the effect of different kernel sizes and sigma values on a sample PNG using Aspose.Imaging’s SharpenFilterOptions.
 */