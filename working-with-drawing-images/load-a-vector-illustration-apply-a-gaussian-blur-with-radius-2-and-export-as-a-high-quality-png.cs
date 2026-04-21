using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (vector illustration)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply raster filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 2 and sigma 1.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(2, 1.0));

            // Prepare high‑quality PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the processed image as PNG
            rasterImage.Save(outputPath, pngOptions);
        }
    }
}