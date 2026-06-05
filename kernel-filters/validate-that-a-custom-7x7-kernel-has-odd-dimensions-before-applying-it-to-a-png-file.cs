using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom 7x7 kernel (example: simple identity kernel)
            double[,] kernel = new double[7, 7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    kernel[i, j] = 0.0;
            kernel[3, 3] = 1.0; // center element

            // Validate that kernel dimensions are odd
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows % 2 == 0 || cols % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            // Load the PNG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply the custom convolution filter
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to apply a custom 7x7 convolution filter to a PNG image in C# and must verify that the kernel dimensions are odd to satisfy Aspose.Imaging’s filter requirements.
 * 2. When processing medical or scientific PNG images where an identity kernel is used to test image integrity before applying more complex transformations.
 * 3. When building an automated graphics pipeline that validates user‑uploaded PNG files and applies a developer‑defined kernel, ensuring the kernel size is odd to prevent runtime errors.
 * 4. When creating a desktop application that sharpens or blurs PNG assets using a custom kernel and needs to check the kernel dimensions before saving the filtered result.
 * 5. When troubleshooting image‑processing scripts by confirming that a custom kernel has odd dimensions before invoking Aspose.Imaging’s convolution filter and saving the output as PNG.
 */