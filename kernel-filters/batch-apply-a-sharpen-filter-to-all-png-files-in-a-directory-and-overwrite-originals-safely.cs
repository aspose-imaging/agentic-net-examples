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
            // Hardcoded input directory containing PNG files
            string inputDirectory = @"C:\Images";

            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path is the same as input path (overwrite)
                string outputPath = inputPath;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply sharpen filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access Filter method
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter with kernel size 5 and sigma 4.0
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image, overwriting the original file
                    rasterImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}