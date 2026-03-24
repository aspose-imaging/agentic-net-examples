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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_edge.png";

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

            // Use an emboss kernel (edge detection) from ConvolutionFilter
            var embossKernel = ConvolutionFilter.Emboss3x3;

            // Create convolution filter options with the emboss kernel
            var filterOptions = new ConvolutionFilterOptions(embossKernel);

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}