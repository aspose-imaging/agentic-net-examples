using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to TiffImage for TIFF-specific operations
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur filter to the whole image
            tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply Sharpen filter to the whole image
            tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            PngOptions pngOptions = new PngOptions();
            tiffImage.Save(outputPath, pngOptions);
        }
    }
}