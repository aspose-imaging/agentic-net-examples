using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Store original dimensions
                int originalWidth = rasterImage.Width;
                int originalHeight = rasterImage.Height;

                // Apply a convolution filter (Gaussian blur as an example)
                var filterOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Verify dimensions remain unchanged
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