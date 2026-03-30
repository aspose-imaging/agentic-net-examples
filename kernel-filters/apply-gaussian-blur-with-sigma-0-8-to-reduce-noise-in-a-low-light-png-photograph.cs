using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\lowlight.png";
        string outputPath = @"C:\Images\lowlight_blurred.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with a kernel size of 3 (odd) and sigma 0.8
            var blurOptions = new GaussianBlurFilterOptions(3, 0.8);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}