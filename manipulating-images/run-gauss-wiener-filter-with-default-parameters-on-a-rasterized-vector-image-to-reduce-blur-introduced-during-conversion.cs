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
            string inputPath = @"C:\Images\vector_rasterized.png";
            string outputPath = @"C:\Images\vector_rasterized_GaussWiener.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener filter with default parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions());

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