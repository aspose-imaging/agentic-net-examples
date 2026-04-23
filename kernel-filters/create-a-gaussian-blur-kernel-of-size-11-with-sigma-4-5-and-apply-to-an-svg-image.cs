using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the loaded image as a raster image
                RasterImage rasterImage = image as RasterImage;

                // If the image is not already rasterized, rasterize it by saving to a temporary raster format
                if (rasterImage == null)
                {
                    // Save the vector image to a temporary PNG to obtain a raster representation
                    string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                    image.Save(tempPath);
                    using (Image tempImage = Image.Load(tempPath))
                    {
                        rasterImage = tempImage as RasterImage;
                        if (rasterImage == null)
                        {
                            Console.Error.WriteLine("Failed to rasterize the SVG image.");
                            return;
                        }

                        // Apply Gaussian blur filter
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(11, 4.5));

                        // Save the processed image to the final output path
                        rasterImage.Save(outputPath);
                    }
                    // Clean up temporary file
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                }
                else
                {
                    // Apply Gaussian blur filter directly
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(11, 4.5));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}