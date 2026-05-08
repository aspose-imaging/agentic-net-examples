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
            // Hardcoded input image path
            string inputPath = @"C:\temp\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output paths for each kernel size
            string outputPath3 = @"C:\temp\sample.GaussianBlur3x3.png";
            string outputPath5 = @"C:\temp\sample.GaussianBlur5x5.png";
            string outputPath7 = @"C:\temp\sample.GaussianBlur7x7.png";

            // Process 3x3 Gaussian blur
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(3, 1.0));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
                rasterImage.Save(outputPath3);
            }

            // Process 5x5 Gaussian blur
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath5));
                rasterImage.Save(outputPath5);
            }

            // Process 7x7 Gaussian blur
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(7, 3.0));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath7));
                rasterImage.Save(outputPath7);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}