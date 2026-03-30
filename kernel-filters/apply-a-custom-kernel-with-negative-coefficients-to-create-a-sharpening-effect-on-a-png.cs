using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpening filter.
            // SharpenFilterOptions internally uses a kernel that contains negative coefficients,
            // providing the desired sharpening effect.
            // Size 3 creates a 3×3 kernel; sigma 0.0 selects the default sharpening behavior.
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 0.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}