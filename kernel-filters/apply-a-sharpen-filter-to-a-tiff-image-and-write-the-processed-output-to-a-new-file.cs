using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific functionality
            TiffImage tiffImage = (TiffImage)image;

            // Apply a sharpen filter to the entire image (kernel size 5, sigma 4.0)
            tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to the output path using default TIFF options
            tiffImage.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
        }
    }
}