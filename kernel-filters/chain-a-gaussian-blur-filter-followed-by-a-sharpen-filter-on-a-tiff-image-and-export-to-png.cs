using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample_processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur filter to the whole image
            tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply sharpen filter to the whole image
            tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the result as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}