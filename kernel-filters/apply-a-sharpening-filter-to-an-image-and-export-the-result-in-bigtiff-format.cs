using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply sharpening, and save as BigTIFF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply sharpen filter to the whole image
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Prepare BigTIFF save options
            var bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);

            // Save the processed image in BigTIFF format
            raster.Save(outputPath, bigTiffOptions);
        }
    }
}