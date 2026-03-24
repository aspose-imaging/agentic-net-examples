using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_blur.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply raster filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur (kernel size 5, sigma 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}