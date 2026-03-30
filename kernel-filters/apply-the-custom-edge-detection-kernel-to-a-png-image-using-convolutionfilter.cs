using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Define a custom edge‑detection kernel (Laplacian)
            double[] kernel = new double[]
            {
                -1, -1, -1,
                -1,  8, -1,
                -1, -1, -1
            };

            // Create convolution filter options
            var options = new ConvolutionFilterOptions(kernel, factor: 1.0, divisor: 1);
            options.BordersProcessing = true;   // Process image borders
            options.Factor = 1.0;                // Scale factor
            options.Bias = 0.0;                  // Bias

            // Apply the convolution filter to the entire image
            raster.Filter(raster.Bounds, options);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}