using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded directory containing PNG files
        string inputDirectory = "C:\\Images\\";

        // Get all PNG files in the directory
        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string filePath in pngFiles)
        {
            // Verify the input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Ensure the output directory exists (same as input directory here)
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Load the image, apply sharpen filter, and overwrite the original file
            using (Image image = Image.Load(filePath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter with kernel size 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save back to the same path, overwriting the original
                rasterImage.Save(filePath);
            }
        }
    }
}