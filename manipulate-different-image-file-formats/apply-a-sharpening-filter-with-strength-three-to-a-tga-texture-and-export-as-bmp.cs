using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\texture.tga";
        string outputPath = @"C:\Images\Processed\texture_sharpened.bmp";

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

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter with size 3 and sigma 1.0 (strength three)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save the result as BMP
                rasterImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}