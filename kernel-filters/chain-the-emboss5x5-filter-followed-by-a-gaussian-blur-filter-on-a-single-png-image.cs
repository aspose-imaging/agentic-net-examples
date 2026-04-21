using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.png";
            string outputPath = "C:\\temp\\output.png";

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
                RasterImage raster = (RasterImage)image;

                // Apply Emboss 5x5 filter
                var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);
                raster.Filter(raster.Bounds, embossOptions);

                // Apply Gaussian blur filter (radius 5, sigma 4.0)
                var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, gaussianOptions);

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}