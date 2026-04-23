using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string intermediatePath = @"C:\Images\temp.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for intermediate and final output
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image and rasterize it to a temporary PNG
            using (Image emfImage = Image.Load(inputPath))
            {
                // Save as PNG using default rasterization options
                emfImage.Save(intermediatePath, new PngOptions());
            }

            // Load the rasterized PNG, apply Gaussian blur, and save the final PNG
            using (Image img = Image.Load(intermediatePath))
            {
                RasterImage rasterImage = (RasterImage)img;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image as PNG
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}