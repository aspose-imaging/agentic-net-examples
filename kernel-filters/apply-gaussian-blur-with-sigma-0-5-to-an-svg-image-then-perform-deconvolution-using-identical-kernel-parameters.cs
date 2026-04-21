using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 3 (odd) and sigma 0.5
                var blurOptions = new GaussianBlurFilterOptions(3, 0.5);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Apply Gaussian deconvolution (Gauss-Wiener) with the same kernel parameters
                var deconvOptions = new GaussWienerFilterOptions(3, 0.5);
                rasterImage.Filter(rasterImage.Bounds, deconvOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}