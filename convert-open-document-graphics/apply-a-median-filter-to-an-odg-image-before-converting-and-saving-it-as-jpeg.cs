using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "result.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply raster filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with a size of 5 to the entire image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the processed image as JPEG
            JpegOptions jpegOptions = new JpegOptions();
            rasterImage.Save(outputPath, jpegOptions);
        }
    }
}