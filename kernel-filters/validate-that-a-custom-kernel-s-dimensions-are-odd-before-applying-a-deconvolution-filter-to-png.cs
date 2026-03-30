using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
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

        // Load the PNG image
        using (PngImage pngImage = (PngImage)Image.Load(inputPath))
        {
            // Define a custom kernel (example 3x3 kernel)
            double[] kernel = new double[]
            {
                0, -1, 0,
                -1, 5, -1,
                0, -1, 0
            };

            // Validate that the kernel represents an odd-sized square matrix
            int length = kernel.Length;
            int size = (int)Math.Sqrt(length);
            if (size * size != length || size % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd and form a square matrix.");
                return;
            }

            // Create deconvolution filter options with the validated kernel
            DeconvolutionFilterOptions filterOptions = new DeconvolutionFilterOptions(kernel);

            // Apply the deconvolution filter to the image
            pngImage.Filter(filterOptions);

            // Save the processed image
            pngImage.Save(outputPath);
        }
    }
}