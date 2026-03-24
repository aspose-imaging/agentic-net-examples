using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.dng";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image with default load options
        using (Image image = Image.Load(inputPath, new DngLoadOptions()))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter (size = 5, sigma = 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}