using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define custom Gaussian kernel parameters
                int kernelSize = 5;          // Must be odd and > 0
                double sigma = 1.0;         // Positive non‑zero sigma

                // Obtain the Gaussian kernel
                double[,] kernel = ConvolutionFilter.GetGaussian(kernelSize, sigma);

                // Normalize the kernel to preserve brightness (sum of elements = 1)
                double sum = 0.0;
                for (int i = 0; i < kernelSize; i++)
                {
                    for (int j = 0; j < kernelSize; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double[,] normalizedKernel = new double[kernelSize, kernelSize];
                for (int i = 0; i < kernelSize; i++)
                {
                    for (int j = 0; j < kernelSize; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Create convolution filter options with the normalized kernel
                var filterOptions = new ConvolutionFilterOptions(normalizedKernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the result as PNG
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer wants to apply a custom Gaussian blur to a PNG image while keeping the overall brightness unchanged, they can use this code to normalize the kernel before convolution.
 * 2. When building an image‑processing pipeline in C# that smooths scanned documents stored as PNG files without introducing darkening or lightening artifacts, the normalized Gaussian kernel ensures consistent exposure.
 * 3. When creating a photo‑editing tool that lets users adjust the blur radius (kernel size) and sigma for PNG assets, normalizing the kernel guarantees that the filtered output retains the original image’s luminance.
 * 4. When automating batch processing of PNG thumbnails for a web gallery and need to reduce noise with a Gaussian filter while preserving visual brightness across all images, this code provides the necessary normalization step.
 * 5. When integrating Aspose.Imaging into a C# application that generates PNG graphics with custom blur effects for UI elements, normalizing the convolution matrix prevents unintended brightness shifts after the filter is applied.
 */