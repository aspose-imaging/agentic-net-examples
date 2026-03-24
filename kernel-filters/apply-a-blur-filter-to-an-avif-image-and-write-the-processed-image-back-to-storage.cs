using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Avif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.avif";
        string outputPath = @"C:\Images\output.avif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to use filtering methods
            var rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}