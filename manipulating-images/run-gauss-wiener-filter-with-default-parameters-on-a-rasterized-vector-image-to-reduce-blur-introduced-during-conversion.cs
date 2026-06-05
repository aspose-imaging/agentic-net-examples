using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vector_rasterized.png";
        string outputPath = @"C:\Images\vector_rasterized_gausswiener.png";

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

            // Load the image and apply Gauss‑Wiener filter with default parameters
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply the filter to the whole image bounds
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions());

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}