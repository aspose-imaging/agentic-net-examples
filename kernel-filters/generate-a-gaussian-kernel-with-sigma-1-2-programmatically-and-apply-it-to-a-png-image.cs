using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_gaussian.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage rasterImage = (RasterImage)image;

            // Create Gaussian blur options with kernel size 5 and sigma 1.2
            var gaussianOptions = new GaussianBlurFilterOptions(5, 1.2);

            // Apply the Gaussian blur to the whole image
            rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}