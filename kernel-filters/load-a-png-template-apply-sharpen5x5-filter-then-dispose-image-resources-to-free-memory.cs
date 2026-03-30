using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\template.png";
        string outputPath = @"C:\temp\output_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, apply Sharpen5x5 filter, and save
        using (Image image = Image.Load(inputPath))
        {
            var rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
            rasterImage.Save(outputPath);
        }
    }
}