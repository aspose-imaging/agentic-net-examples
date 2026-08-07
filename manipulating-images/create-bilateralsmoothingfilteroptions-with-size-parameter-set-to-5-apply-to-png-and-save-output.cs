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
            string outputPath = @"C:\Images\sample.BilateralSmoothingFilter.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply bilateral smoothing filter, and save
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter with kernel size 5
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Save the processed image as PNG
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
 * 1. When a developer needs to reduce noise in a scanned PNG document while preserving edges for OCR preprocessing, they can apply a bilateral smoothing filter with size 5 and save the cleaned image.
 * 2. When building a web service that automatically optimizes user‑uploaded PNG avatars, the code can smooth the image to remove compression artifacts before storing the result.
 * 3. When creating a desktop application that prepares PNG screenshots for printing, a bilateral smoothing filter with a kernel size of 5 can be used to improve visual quality without blurring important details.
 * 4. When integrating image processing into a C# batch job that processes a folder of PNG assets for a game, the filter can be applied to each image to achieve consistent noise reduction across the asset pipeline.
 * 5. When developing a medical imaging tool that visualizes PNG‑encoded microscopy slides, applying bilateral smoothing with size 5 helps enhance tissue structures while keeping edges sharp for accurate analysis.
 */