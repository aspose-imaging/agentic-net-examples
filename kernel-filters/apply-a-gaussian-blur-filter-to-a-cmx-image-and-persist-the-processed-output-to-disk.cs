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
        string outputPath = @"C:\Images\sample_gaussian.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Attempt to treat the loaded image as a raster image
            if (image is RasterImage rasterImage)
            {
                // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image to the output path (PNG format)
                rasterImage.Save(outputPath);
            }
            else
            {
                // If the image is not rasterizable, report the limitation
                Console.Error.WriteLine("The loaded CMX image cannot be processed as a raster image.");
            }
        }
    }
}