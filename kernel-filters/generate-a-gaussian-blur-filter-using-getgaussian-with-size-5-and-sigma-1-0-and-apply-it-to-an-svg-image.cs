using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

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
            // Cast to RasterImage (Aspose.Imaging rasterizes the vector image on demand)
            using (RasterImage raster = (RasterImage)image)
            {
                // Optional: retrieve the Gaussian kernel (not directly used)
                double[] kernel = ConvolutionFilter.GetGaussian(5, 1.0);

                // Create Gaussian blur filter options with size 5 and sigma 1.0
                var blurOptions = new GaussianBlurFilterOptions(5, 1.0);

                // Apply the filter to the whole image
                raster.Filter(raster.Bounds, blurOptions);

                // Save the processed image
                raster.Save(outputPath);
            }
        }
    }
}