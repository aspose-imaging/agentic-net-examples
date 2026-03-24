using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.jp2";
        string outputPath = @"c:\temp\sample.sharpened.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG2000 image
        using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)jpeg2000Image;

            // Apply a sharpen filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image back to JPEG2000 format
            jpeg2000Image.Save(outputPath, new Jpeg2000Options());
        }
    }
}