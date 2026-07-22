using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? string.Empty;
            Directory.CreateDirectory(outputDir);

            // Define a custom kernel (example 3x3 kernel)
            double[,] kernel = new double[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            };

            // Normalize kernel so that the sum of coefficients equals 1
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    sum += kernel[i, j];
                }
            }

            if (sum != 0)
            {
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom normalized kernel using ConvolutionFilterOptions
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as JPEG
                raster.Save(outputPath);
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
 * 1. When a developer wants to apply a custom blur or sharpening effect to a JPEG image and needs the kernel coefficients to sum to one to preserve overall brightness, they can use this code with Aspose.Imaging for .NET.
 * 2. When building an automated photo‑processing pipeline that must normalize user‑defined convolution kernels before applying them to JPEG files to avoid color shifts, this example shows the required steps in C#.
 * 3. When implementing a desktop application that lets users upload a JPEG, select a custom edge‑detection kernel, and see the result without over‑exposing the image, the code demonstrates kernel normalization and convolution using Aspose.Imaging.
 * 4. When creating a batch‑processing script that reads multiple JPEGs, applies a custom Gaussian‑like kernel, and saves the filtered images while ensuring the sum of the kernel equals one, this snippet provides the necessary logic.
 * 5. When integrating image‑enhancement features such as noise reduction or detail enhancement into a .NET web service that processes JPEG uploads, the example illustrates how to normalize the kernel and apply it with ConvolutionFilterOptions.
 */