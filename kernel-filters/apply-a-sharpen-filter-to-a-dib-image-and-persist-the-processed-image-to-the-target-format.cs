using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.dib";
        string outputPath = @"C:\output\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DIB image, apply Sharpen filter, and save to target format
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Apply Sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            raster.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}