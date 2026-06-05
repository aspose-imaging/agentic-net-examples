using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;
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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 3x3 sharpening kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Apply the convolution filter with the custom kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Verify that all pixel channel values are within 0‑255
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool allValid = true;
                foreach (int argb in pixels)
                {
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        allValid = false;
                        break;
                    }
                }

                Console.WriteLine(allValid
                    ? "All pixel values are within 0-255."
                    : "Pixel values out of range detected.");

                // Save the processed image
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When a developer needs to apply a custom sharpening filter to a PNG image and confirm that the convolution does not produce out‑of‑range pixel values before saving the result.
 * 2. When building an automated image‑processing pipeline that must guarantee all ARGB channel values stay within the 0‑255 range to avoid corruption of downstream PNG or JPEG files.
 * 3. When performing quality‑control checks on scanned documents after applying a convolution kernel to ensure the pixel intensity remains valid for OCR engines.
 * 4. When creating a C# utility that processes user‑uploaded PNGs, applies a custom filter, and validates pixel data to prevent runtime exceptions in web applications.
 * 5. When developing a batch‑conversion tool that sharpens PNG assets for a game and needs to verify that no pixel overflow occurs, preserving correct color depth across all frames.
 */