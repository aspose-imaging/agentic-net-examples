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
            string inputPath = "input\\sample.png";
            string outputPath = "output\\sample_processed.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // ---- Background removal step (placeholder) ----
                // Insert background removal logic here.
                // Example: make all fully transparent pixels white, etc.

                // Apply median filter with kernel size 3 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(3));

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