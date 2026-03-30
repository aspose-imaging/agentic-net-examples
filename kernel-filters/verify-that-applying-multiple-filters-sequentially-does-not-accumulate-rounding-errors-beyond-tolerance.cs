using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Apply filters sequentially and save the result
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // First filter: Sharpen
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Second filter: Gaussian blur
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(3, 1.5));

            // Save the filtered image
            raster.Save(outputPath);
        }

        // Load the saved image for pixel comparison
        using (Aspose.Imaging.Image savedImg = Aspose.Imaging.Image.Load(outputPath))
        using (Aspose.Imaging.Image freshImg = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage savedRaster = (Aspose.Imaging.RasterImage)savedImg;
            Aspose.Imaging.RasterImage freshRaster = (Aspose.Imaging.RasterImage)freshImg;

            // Apply the same filters on a fresh copy of the original image
            freshRaster.Filter(freshRaster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            freshRaster.Filter(freshRaster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(3, 1.5));

            // Retrieve pixel data
            int[] savedPixels = savedRaster.GetDefaultArgb32Pixels(savedRaster.Bounds);
            int[] freshPixels = freshRaster.GetDefaultArgb32Pixels(freshRaster.Bounds);

            // Compute average per‑channel absolute difference
            long totalDiff = 0;
            for (int i = 0; i < savedPixels.Length; i++)
            {
                int p1 = savedPixels[i];
                int p2 = freshPixels[i];

                int a1 = (p1 >> 24) & 0xFF;
                int r1 = (p1 >> 16) & 0xFF;
                int g1 = (p1 >> 8) & 0xFF;
                int b1 = p1 & 0xFF;

                int a2 = (p2 >> 24) & 0xFF;
                int r2 = (p2 >> 16) & 0xFF;
                int g2 = (p2 >> 8) & 0xFF;
                int b2 = p2 & 0xFF;

                totalDiff += Math.Abs(a1 - a2) + Math.Abs(r1 - r2) +
                             Math.Abs(g1 - g2) + Math.Abs(b1 - b2);
            }

            double avgDiff = (double)totalDiff / (savedPixels.Length * 4);
            double tolerance = 0.5; // Example tolerance

            Console.WriteLine($"Average per‑channel difference: {avgDiff:F4}");
            if (avgDiff <= tolerance)
                Console.WriteLine("Rounding error is within tolerance.");
            else
                Console.WriteLine("Rounding error exceeds tolerance.");
        }
    }
}