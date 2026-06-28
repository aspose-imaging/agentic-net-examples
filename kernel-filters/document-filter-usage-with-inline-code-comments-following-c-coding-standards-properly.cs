using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

namespace AsposeImagingFilterDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.SharpenFilter.png";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image from disk
                using (Image image = Image.Load(inputPath))
                {
                    // Cast the generic Image to RasterImage to access filtering capabilities
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the specified output path
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any unexpected errors without crashing the application
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically enhance the visual clarity of scanned PNG documents before archiving them, they can use this code to apply a sharpen filter with a 5‑pixel kernel and sigma 4.0.
 * 2. When building a batch image‑processing pipeline that prepares product photos for an e‑commerce website, the code can load each raster image, sharpen it, and save the result in the same format.
 * 3. When integrating Aspose.Imaging into a C# desktop application that lets users improve blurry screenshots, the snippet demonstrates how to verify file existence, apply a sharpen filter, and write the output safely.
 * 4. When creating a server‑side service that receives user‑uploaded PNG files and returns a sharpened version for better OCR accuracy, this example shows the necessary steps to load, filter, and save the image.
 * 5. When developing automated tests for image‑processing algorithms, the code provides a reproducible way to apply a known sharpening operation to a sample image and compare the output against expected results.
 */