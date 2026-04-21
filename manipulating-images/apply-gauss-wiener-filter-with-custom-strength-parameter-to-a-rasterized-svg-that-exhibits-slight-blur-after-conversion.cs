using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

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
            // Load the rasterized image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Configure Gauss‑Wiener filter (size = 7, sigma = 3.0)
                var gaussWienerOptions = new GaussWienerFilterOptions(7, 3.0);

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, gaussWienerOptions);

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