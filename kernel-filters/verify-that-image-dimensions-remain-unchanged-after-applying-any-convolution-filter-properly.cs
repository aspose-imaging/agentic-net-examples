// HOW-TO: Check That Image Dimensions Remain Same After Applying Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Store original dimensions
                int originalWidth = rasterImage.Width;
                int originalHeight = rasterImage.Height;

                // Apply a convolution filter (Gaussian blur in this example)
                var filterOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Verify dimensions are unchanged
                bool dimensionsUnchanged = rasterImage.Width == originalWidth && rasterImage.Height == originalHeight;
                Console.WriteLine(dimensionsUnchanged
                    ? "Image dimensions unchanged after filter."
                    : "Image dimensions changed after filter.");

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When you need to apply a Gaussian blur to a PNG while ensuring the original width and height stay unchanged for layout consistency.
 * 2. When validating an image processing pipeline that uses convolution filters and you must confirm that the filter does not alter image dimensions before further processing.
 * 3. When integrating Aspose.Imaging in a C# application to batch‑process photos and you need a quick check that each filtered image retains its original size.
 * 4. When creating a thumbnail generator that applies blur effects and you must guarantee the output dimensions match the source to avoid stretching in UI components.
 * 5. When debugging a custom filter implementation and you want to log whether the filter unintentionally resized the raster image.
 */
