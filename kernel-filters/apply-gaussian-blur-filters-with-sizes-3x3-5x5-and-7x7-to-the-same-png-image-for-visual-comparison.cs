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
            // Hardcoded input PNG image path
            string inputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output paths for each kernel size
            string outputPath3 = @"C:\Images\sample.GaussianBlur_3x3.png";
            string outputPath5 = @"C:\Images\sample.GaussianBlur_5x5.png";
            string outputPath7 = @"C:\Images\sample.GaussianBlur_7x7.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath7));

            // Apply 3x3 Gaussian blur (size = 3, sigma = 1.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(3, 1.0));
                rasterImage.Save(outputPath3);
            }

            // Apply 5x5 Gaussian blur (size = 5, sigma = 2.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 2.0));
                rasterImage.Save(outputPath5);
            }

            // Apply 7x7 Gaussian blur (size = 7, sigma = 3.0)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(7, 3.0));
                rasterImage.Save(outputPath7);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}