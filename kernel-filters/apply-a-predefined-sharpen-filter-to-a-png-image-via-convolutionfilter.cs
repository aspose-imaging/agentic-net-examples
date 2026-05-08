using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.Sharpened.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Prepare convolution filter options using the built‑in sharpen kernel (3x3)
                // Parameters: kernel matrix, factor, bias
                var sharpenOptions = new ConvolutionFilterOptions(
                    ConvolutionFilter.Sharpen3x3, // 3x3 sharpen kernel
                    factor: 1.0,                  // scaling factor
                    bias: 0);                     // bias

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                // Save the processed image as PNG
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}