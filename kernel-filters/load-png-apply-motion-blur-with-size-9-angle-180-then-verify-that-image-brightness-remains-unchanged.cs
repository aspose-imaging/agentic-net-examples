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
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Compute original average brightness
                double originalBrightness = ComputeAverageBrightness(rasterImage);

                // Apply motion blur using MotionWienerFilterOptions (size 9, smooth 1.0, angle 180)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new MotionWienerFilterOptions(9, 1.0, 180.0));

                // Compute brightness after filter
                double filteredBrightness = ComputeAverageBrightness(rasterImage);

                // Verify brightness unchanged (allow tiny tolerance)
                const double tolerance = 0.001;
                if (Math.Abs(originalBrightness - filteredBrightness) > tolerance)
                {
                    Console.Error.WriteLine("Warning: Image brightness changed after applying motion blur.");
                }

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute average perceived brightness of a RasterImage
    private static double ComputeAverageBrightness(RasterImage rasterImage)
    {
        // Get all ARGB pixels
        int[] argbPixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
        double totalBrightness = 0;
        foreach (int argb in argbPixels)
        {
            // Extract color components
            int a = (argb >> 24) & 0xFF; // Alpha (unused in brightness)
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;

            // Perceived luminance formula
            double luminance = 0.299 * r + 0.587 * g + 0.114 * b;
            totalBrightness += luminance;
        }

        return totalBrightness / argbPixels.Length;
    }
}