// HOW-TO: Validate Convolution Kernel Sum Equals One Before Applying Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                { 0.0, -1.0, 0.0 },
                { -1.0, 5.0, -1.0 },
                { 0.0, -1.0, 0.0 }
            };

            // Validate that the sum of kernel coefficients equals 1
            double sum = 0.0;
            foreach (double value in kernel)
            {
                sum += value;
            }

            if (Math.Abs(sum - 1.0) > 1e-6)
            {
                Console.Error.WriteLine("Kernel coefficients must sum to 1.");
                return;
            }

            // Load the image, apply the filter, and save the result
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply custom convolution filter
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                // Save the processed image as PNG
                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to sharpen a PNG image with a custom kernel while ensuring the filter does not unintentionally alter overall brightness.
 * 2. When processing user‑uploaded images in a web service and you must verify the convolution matrix is normalized before applying it with Aspose.Imaging.
 * 3. When building an automated batch job that applies edge‑enhancement to thousands of PNG files and you want to prevent runtime errors caused by invalid kernel sums.
 * 4. When creating a C# desktop application that lets designers experiment with custom filters and you need to guard against non‑unit‑sum kernels that could produce dark or washed‑out results.
 * 5. When integrating Aspose.Imaging into a CI pipeline to generate test images and you must programmatically confirm the convolution coefficients total one to maintain consistent test output.
 */
