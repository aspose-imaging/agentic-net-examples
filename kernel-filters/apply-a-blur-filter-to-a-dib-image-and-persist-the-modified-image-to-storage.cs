using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.dib";
        string outputPath = @"C:\Images\output\sample_blurred.dib";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter to the entire image
            // Radius = 5 pixels, Sigma = 4.0 (example values)
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the modified image
            rasterImage.Save(outputPath);
        }
    }
}