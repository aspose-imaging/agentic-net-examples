using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG with default options
            raster.Save(outputPath, new PngOptions());
        }
    }
}