using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\vectorIllustration.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (vector illustration). Aspose.Imaging will handle rasterization internally.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply raster filters
            RasterImage rasterImage = image as RasterImage;
            if (rasterImage == null)
            {
                Console.Error.WriteLine("The loaded image could not be treated as a raster image.");
                return;
            }

            // Apply Gaussian blur with radius 2 and a sigma of 1.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(2, 1.0));

            // Prepare high‑quality PNG save options
            var pngOptions = new PngOptions
            {
                // Example of high‑quality settings (default values are already high quality)
                // You can adjust compression level if needed:
                // PngCompressionLevel = 9
            };

            // Save the processed image as PNG
            rasterImage.Save(outputPath, pngOptions);
        }
    }
}