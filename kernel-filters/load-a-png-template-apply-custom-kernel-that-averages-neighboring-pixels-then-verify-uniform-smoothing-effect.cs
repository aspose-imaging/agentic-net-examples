using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Path safety rules
        string inputPath = @"C:\Images\template.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG template
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a simple averaging kernel using Gaussian blur with radius 1 and sigma 1.0
                // This approximates the effect of averaging neighboring pixels.
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(1, 1.0));

                // Save the processed image
                rasterImage.Save(outputPath);
            }

            // Simple verification: check that the output file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("Filter applied and output saved successfully.");
            }
            else
            {
                Console.Error.WriteLine("Failed to save the output image.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}