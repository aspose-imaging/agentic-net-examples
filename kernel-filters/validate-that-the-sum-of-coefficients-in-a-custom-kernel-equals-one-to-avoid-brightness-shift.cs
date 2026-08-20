// HOW-TO: Validate Convolution Kernel Sum Before Applying Filter in C# (Aspose.Imaging for .NET)
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

            // Load image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define a custom convolution kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Validate that the sum of kernel coefficients equals 1
                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                if (Math.Abs(sum - 1.0) > 1e-6)
                {
                    Console.WriteLine($"Warning: Kernel sum is {sum}, not equal to 1. This may cause brightness shift.");
                }

                // Apply convolution filter using the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to sharpen a PNG image with a custom kernel while ensuring the brightness stays unchanged.
 * 2. When you want to programmatically verify that a convolution matrix is normalized before applying it to avoid unintended lighting changes.
 * 3. When processing batch images in a .NET application and you must create an output folder automatically if it doesn’t exist.
 * 4. When you need to load a raster image, apply a user‑defined filter, and save the result as a PNG using Aspose.Imaging.
 * 5. When you want to display a warning in the console if the sum of kernel coefficients deviates from 1, helping debug image‑filter issues.
 */
