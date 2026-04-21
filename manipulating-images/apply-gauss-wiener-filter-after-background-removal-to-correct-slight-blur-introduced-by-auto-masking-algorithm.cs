using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // ----- Background removal step (placeholder) -----
                // If a specific background removal filter is available, apply it here.
                // Example (if such a filter existed):
                // rasterImage.Filter(rasterImage.Bounds, new BackgroundRemovalFilterOptions());

                // Apply Gauss‑Wiener filter to correct blur introduced by background removal
                var gaussWienerOptions = new GaussWienerFilterOptions(5, 4.0);
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