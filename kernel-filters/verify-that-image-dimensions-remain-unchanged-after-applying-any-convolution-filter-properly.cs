// HOW-TO: Check Image Dimensions Remain Same After Gaussian Blur In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.png";
        string outputPath = "output\\filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
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

                // Verify dimensions after filtering
                int newWidth = rasterImage.Width;
                int newHeight = rasterImage.Height;

                if (originalWidth != newWidth || originalHeight != newHeight)
                {
                    Console.WriteLine("Dimensions changed after applying the filter!");
                }
                else
                {
                    Console.WriteLine("Image dimensions remain unchanged after applying the filter.");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image
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
 * 1. When you need to apply a Gaussian blur to a PNG without altering its width and height.
 * 2. When validating that image processing operations in a .NET application preserve original dimensions for downstream layout calculations.
 * 3. When automating batch image filtering and you must ensure the filtered files can replace the originals without breaking UI constraints.
 * 4. When debugging custom filter pipelines and you want a quick console check that the filter does not resize the raster.
 * 5. When integrating Aspose.Imaging into a C# service that processes user‑uploaded images and you must guarantee size consistency after applying any convolution filter.
 */
