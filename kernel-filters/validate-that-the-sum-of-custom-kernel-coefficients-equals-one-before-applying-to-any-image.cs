using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            // Define a custom 3x3 kernel whose coefficients sum to 1
            double[,] kernel = new double[,]
            {
                { 0.0, -1.0, 0.0 },
                { -1.0, 5.0, -1.0 },
                { 0.0, -1.0, 0.0 }
            };

            // Validate that the sum of kernel coefficients equals 1
            double sum = kernel.Cast<double>().Sum();
            if (Math.Abs(sum - 1.0) > 1e-6)
            {
                Console.Error.WriteLine("Kernel coefficients must sum to 1.");
                return;
            }

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply the custom convolution filter
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}