using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Load the PNG image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Define a custom 3x3 sharpening kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };

                // Create convolution filter options with the custom kernel
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the custom kernel to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Verify that all pixel channel values are within 0‑255
                int[] argbPixels = raster.LoadArgb32Pixels(raster.Bounds);
                foreach (int pixel in argbPixels)
                {
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;

                    if (a < 0 || a > 255 ||
                        r < 0 || r > 255 ||
                        g < 0 || g > 255 ||
                        b < 0 || b > 255)
                    {
                        Console.Error.WriteLine("Pixel value out of range detected.");
                        return;
                    }
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                saveOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a developer needs to sharpen a PNG image with a custom 3×3 convolution kernel in C# and verify that all ARGB channel values stay within the 0‑255 range to prevent color distortion.
 * 2. When building an automated image‑processing pipeline that applies a filter to uploaded PNG files using Aspose.Imaging and must ensure no pixel overflow occurs before saving the result.
 * 3. When creating a desktop application that lets users enhance photos with custom kernels and requires validation that the processed PNG remains compatible with standard viewers by keeping each pixel channel between 0 and 255.
 * 4. When performing batch processing of PNG assets for a game, applying a sharpening kernel with Aspose.Imaging while checking every pixel’s alpha, red, green, and blue components to avoid rendering artifacts.
 * 5. When integrating image quality checks into a CI/CD workflow that runs C# tests on PNG transformations, needing to confirm that convolution does not produce out‑of‑range pixel values.
 */