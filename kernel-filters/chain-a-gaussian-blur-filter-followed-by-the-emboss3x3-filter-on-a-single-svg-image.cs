using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\sample_processed.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to enable filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur (size = 5, sigma = 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply Emboss3x3 convolution filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}