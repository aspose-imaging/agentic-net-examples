using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom convolution kernel
            double[,] kernel = new double[,]
            {
                { 0.0, 0.5, 0.0 },
                { 0.5, -2.0, 0.5 },
                { 0.0, 0.5, 0.0 }
            };

            // Validate that the sum of kernel coefficients equals 1
            double sum = 0.0;
            foreach (double value in kernel)
                sum += value;

            if (Math.Abs(sum - 1.0) > 1e-6)
            {
                Console.Error.WriteLine("Kernel coefficients must sum to 1.");
                return;
            }

            // Load the image, apply the filter, and save the result
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                // Create filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}