// HOW-TO: Apply Bilateral Smoothing Sharpen and Median Filters Pipeline in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Reusable pipeline that applies bilateral smoothing, sharpening, then median filter
    static void ApplyFilterPipeline(string inputPath, string outputPath)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply bilateral smoothing filter with kernel size 5
            rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

            // Apply sharpen filter with kernel size 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Apply median filter with size 5
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }

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

            // Run the filter pipeline
            ApplyFilterPipeline(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce noise while preserving edges in a PNG before uploading it to a web gallery, you can use this Aspose.Imaging filter pipeline in C#.
 * 2. When processing scanned documents in JPEG format to improve readability by smoothing artifacts and sharpening text, the code provides a reusable sequence of bilateral, sharpen, and median filters.
 * 3. When building an automated image‑enhancement service that must apply consistent noise reduction and detail enhancement to thousands of photos, the pipeline can be called repeatedly for each file.
 * 4. When preparing medical or satellite images for analysis, applying bilateral smoothing followed by sharpening and median filtering helps enhance features without introducing new artifacts.
 * 5. When integrating image preprocessing into a C# desktop application that loads user‑selected images, this code shows how to load, filter, and save the result using Aspose.Imaging’s RasterImage API.
 */
