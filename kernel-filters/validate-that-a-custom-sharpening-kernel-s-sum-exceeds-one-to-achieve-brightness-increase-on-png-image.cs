using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

// Main program
class Program
{
    static void Main()
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

        // Define a custom sharpening kernel (3x3)
        // Example kernel: center weight increased to 6 to make sum > 1
        double[] customKernel = new double[]
        {
            0, -1, 0,
            -1, 6, -1,
            0, -1, 0
        };

        // Calculate the sum of kernel elements
        double kernelSum = 0;
        foreach (double v in customKernel)
            kernelSum += v;

        // Validate that the kernel sum exceeds one
        if (kernelSum <= 1.0)
        {
            Console.Error.WriteLine($"Invalid kernel: sum ({kernelSum}) must be greater than 1 to increase brightness.");
            return;
        }

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply the custom sharpening kernel using ConvolutionFilter
            // ConvolutionFilter provides static method ToComplex to convert kernel to required format
            // The size of the kernel is 3 (since it's 3x3)
            rasterImage.Filter(
                rasterImage.Bounds,
                new ConvolutionFilterOptions(customKernel, 3));

            // Save the processed image
            rasterImage.Save(outputPath);
        }

        Console.WriteLine("Image processing completed successfully.");
    }
}

// Supporting class for applying a custom convolution kernel
// This class wraps the kernel into a filter option compatible with RasterImage.Filter
class ConvolutionFilterOptions : FilterOptionsBase
{
    public double[] Kernel { get; }
    public int Size { get; }

    public ConvolutionFilterOptions(double[] kernel, int size)
    {
        Kernel = kernel;
        Size = size;
    }

    // The RasterImage.Filter method expects an object derived from FilterOptionsBase.
    // The actual implementation details are handled internally by Aspose.Imaging.
}