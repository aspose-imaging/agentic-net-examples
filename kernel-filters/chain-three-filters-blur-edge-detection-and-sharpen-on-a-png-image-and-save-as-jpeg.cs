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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.jpg";

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
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply edge detection (assuming EdgeDetectionFilterOptions exists)
            raster.Filter(raster.Bounds, new EdgeDetectionFilterOptions());

            // Apply sharpen filter
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the result as JPEG
            JpegOptions jpegOptions = new JpegOptions();
            raster.Save(outputPath, jpegOptions);
        }
    }
}