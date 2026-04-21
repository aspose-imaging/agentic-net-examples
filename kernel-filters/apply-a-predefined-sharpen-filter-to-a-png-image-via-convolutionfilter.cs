using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "sample.sharpened.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply predefined sharpen kernel via ConvolutionFilterOptions
                // Sharpen3x3 kernel, factor 1.0, bias 0
                var sharpenOptions = new ConvolutionFilterOptions(
                    ConvolutionFilter.Sharpen3x3, // kernel
                    1.0,                         // factor
                    0);                          // bias

                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

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