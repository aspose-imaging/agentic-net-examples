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

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // -----------------------------------------------------------------
                // Best practice: Apply kernel-based filters (e.g., sharpen) and then
                // normalize brightness/contrast to keep visual consistency across
                // different filters. This prevents cumulative brightness shifts.
                // -----------------------------------------------------------------

                // Example: Apply a sharpen filter with a 5x5 kernel and sigma 4.0
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

                // After applying the filter, normalize the image histogram.
                // This spreads pixel values across the full dynamic range.
                rasterImage.NormalizeHistogram();

                // Finally, perform adaptive brightness/contrast normalization.
                // AutoBrightnessContrast uses CLAHE, adaptive white stretch,
                // and auto white balance to achieve consistent brightness.
                rasterImage.AutoBrightnessContrast();

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