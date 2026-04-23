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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Define a custom convolution kernel
            double[,] kernel = new double[,]
            {
                { 0.0,  -1.0,  0.0 },
                { -1.0,  5.0, -1.0 },
                { 0.0,  -1.0,  0.0 }
            };

            // Validate that the sum of kernel coefficients equals 1
            double sum = 0.0;
            for (int y = 0; y < kernel.GetLength(0); y++)
            {
                for (int x = 0; x < kernel.GetLength(1); x++)
                {
                    sum += kernel[y, x];
                }
            }

            const double tolerance = 1e-6;
            if (Math.Abs(sum - 1.0) > tolerance)
            {
                Console.Error.WriteLine($"Kernel sum is {sum}, which does not equal 1. Adjust the kernel to avoid brightness shift.");
                return;
            }

            // Apply the custom convolution filter
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}