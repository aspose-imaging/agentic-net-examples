// HOW-TO: Validate Odd-Sized Convolution Kernel Before Applying to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

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

            // Define a custom 7x7 kernel
            double[,] kernel = new double[7, 7]
            {
                { 0, 0, 1, 2, 1, 0, 0 },
                { 0, 3, 5, 8, 5, 3, 0 },
                { 1, 5, 9,13, 9, 5, 1 },
                { 2, 8,13,20,13, 8, 2 },
                { 1, 5, 9,13, 9, 5, 1 },
                { 0, 3, 5, 8, 5, 3, 0 },
                { 0, 0, 1, 2, 1, 0, 0 }
            };

            // Validate that kernel dimensions are odd
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows % 2 == 0 || cols % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            // Load the PNG image and apply the custom convolution filter
            using (Image image = Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply the convolution filter with the custom kernel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Save the processed image
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
 * 1. When you need to sharpen or blur a PNG image using a custom 7x7 convolution matrix and must ensure the kernel size is odd to avoid runtime errors.
 * 2. When processing medical or satellite imagery in C# where a specific odd‑dimensional filter is required for edge detection before saving the result as PNG.
 * 3. When building an automated image‑processing pipeline that applies user‑defined filters and you want to validate kernel dimensions to prevent invalid filter configurations.
 * 4. When integrating Aspose.Imaging into a desktop application that lets users upload PNG files and apply custom convolution effects, requiring a pre‑check for odd kernel sizes.
 * 5. When performing batch image enhancement on PNG assets with a handcrafted filter and need to programmatically verify the kernel meets the odd‑size requirement to maintain consistent results.
 */
