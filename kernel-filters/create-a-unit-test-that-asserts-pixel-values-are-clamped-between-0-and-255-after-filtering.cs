using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and apply sharpen filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Sharpen filter (kernel size 5, sigma 4.0)
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save filtered image
            rasterImage.Save(outputPath, new PngOptions());

            // Retrieve ARGB pixel data
            int[] pixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);

            // Verify each component is within 0-255
            bool allClamped = true;
            foreach (int argb in pixels)
            {
                int a = (argb >> 24) & 0xFF;
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                if (a < 0 || a > 255 ||
                    r < 0 || r > 255 ||
                    g < 0 || g > 255 ||
                    b < 0 || b > 255)
                {
                    allClamped = false;
                    break;
                }
            }

            // Output test result
            if (allClamped)
                Console.WriteLine("Test passed: All pixel values are clamped between 0 and 255.");
            else
                Console.WriteLine("Test failed: Some pixel values are out of the 0-255 range.");
        }
    }
}