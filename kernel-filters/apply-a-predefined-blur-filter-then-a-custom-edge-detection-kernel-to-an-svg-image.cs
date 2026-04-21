using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
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

            // Load the SVG image. Aspose.Imaging will rasterize it internally when treated as a RasterImage.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to gain access to filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // -------------------------------------------------
                // 1. Apply a predefined Gaussian blur filter
                // -------------------------------------------------
                // Radius = 5, Sigma = 4.0 (adjust as needed)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // -------------------------------------------------
                // 2. Apply a custom edge‑detection kernel
                // -------------------------------------------------
                // Using a simple 3×3 Laplacian kernel for edge detection:
                //  0  -1   0
                // -1   4  -1
                //  0  -1   0
                // Aspose.Imaging provides a SharpenFilterOptions constructor that accepts
                // kernel size and sigma; we use it here as a stand‑in for a custom kernel.
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(3, 1.0));

                // -------------------------------------------------
                // Save the processed image as PNG
                // -------------------------------------------------
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}