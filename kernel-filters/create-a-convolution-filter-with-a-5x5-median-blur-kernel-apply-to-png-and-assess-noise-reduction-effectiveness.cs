using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\noisy.png";
        string outputPath = @"C:\Images\noisy_median.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the original PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access pixel data and filtering
            RasterImage rasterImage = (RasterImage)image;

            // Compute noise metric (standard deviation of grayscale values) before filtering
            double originalStdDev = ComputeGrayscaleStdDev(rasterImage);
            Console.WriteLine($"Original image grayscale standard deviation: {originalStdDev:F2}");

            // Apply a 5x5 median filter (median blur kernel)
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Compute noise metric after filtering
            double filteredStdDev = ComputeGrayscaleStdDev(rasterImage);
            Console.WriteLine($"Filtered image grayscale standard deviation: {filteredStdDev:F2}");

            // Assess noise reduction effectiveness
            double reduction = (originalStdDev - filteredStdDev) / originalStdDev * 100.0;
            Console.WriteLine($"Noise reduction: {reduction:F2}%");

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }

    // Helper method to compute standard deviation of grayscale pixel values
    private static double ComputeGrayscaleStdDev(RasterImage raster)
    {
        long width = raster.Width;
        long height = raster.Height;
        double sum = 0.0;
        double sumSq = 0.0;
        long totalPixels = width * height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get pixel color
                var color = raster.GetPixel(x, y);
                // Convert to grayscale using average method
                double gray = (color.R + color.G + color.B) / 3.0;
                sum += gray;
                sumSq += gray * gray;
            }
        }

        double mean = sum / totalPixels;
        double variance = (sumSq / totalPixels) - (mean * mean);
        return Math.Sqrt(variance);
    }
}