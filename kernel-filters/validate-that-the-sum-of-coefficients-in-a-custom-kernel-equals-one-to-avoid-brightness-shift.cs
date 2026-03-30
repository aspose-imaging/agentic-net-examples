using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

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
            { 0.5, 0.0, 0.5 },
            { 0.0, 0.5, 0.0 }
        };

        // Validate that the sum of coefficients equals 1 (within a small tolerance)
        double sum = 0.0;
        foreach (double value in kernel)
        {
            sum += value;
        }

        const double tolerance = 1e-6;
        if (Math.Abs(sum - 1.0) > tolerance)
        {
            Console.Error.WriteLine($"Kernel coefficients sum to {sum}, which is not equal to 1. Adjust the kernel to avoid brightness shift.");
            return;
        }

        // Load the image, apply the convolution filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
            raster.Save(outputPath);
        }
    }
}