using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample.GaussianBlur.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            tiffImage.Save(outputPath);
        }
    }
}