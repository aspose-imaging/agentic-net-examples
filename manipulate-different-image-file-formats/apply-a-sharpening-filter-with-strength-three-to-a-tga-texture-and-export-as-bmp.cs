using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tga";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter (strength three) using size=3, sigma=3.0
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 3.0));

            // Save the result as BMP
            rasterImage.Save(outputPath);
        }
    }
}