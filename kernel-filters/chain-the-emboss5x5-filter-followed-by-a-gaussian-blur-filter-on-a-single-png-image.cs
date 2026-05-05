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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Emboss5x5 filter
                var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);
                rasterImage.Filter(rasterImage.Bounds, embossOptions);

                // Apply Gaussian blur filter (radius 5, sigma 4.0)
                var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

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