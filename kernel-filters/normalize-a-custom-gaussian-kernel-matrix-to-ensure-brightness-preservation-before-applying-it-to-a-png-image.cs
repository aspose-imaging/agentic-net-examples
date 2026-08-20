// HOW-TO: Normalize Custom Gaussian Kernel for PNG Convolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom Gaussian kernel (example 3x3)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                // Compute the sum of all kernel elements
                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                // Normalize the kernel to preserve brightness
                double[,] normalizedKernel = new double[kernel.GetLength(0), kernel.GetLength(1)];
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Apply the custom normalized kernel as a convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(normalizedKernel));

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to blur a PNG while keeping its overall brightness unchanged, you can normalize a custom Gaussian kernel before applying a convolution filter with Aspose.Imaging in C#.
 * 2. When processing medical or satellite PNG images where precise intensity levels must be maintained, normalizing the kernel ensures the filter does not alter pixel brightness.
 * 3. When building a photo‑editing application that lets users define their own blur strength, you must compute and normalize the kernel matrix to apply consistent results across different images.
 * 4. When automating batch image enhancement for e‑commerce product photos, normalizing the Gaussian kernel prevents washed‑out colors after applying the smoothing filter.
 * 5. When integrating Aspose.Imaging into a C# service that prepares PNG assets for machine‑learning models, preserving brightness through kernel normalization keeps the training data statistically accurate.
 */
