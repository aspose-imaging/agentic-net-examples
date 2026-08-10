// HOW-TO: Apply Zero Sum Edge Detection Kernel to PNG and Verify Dark Background in C# (Aspose.Imaging for .NET)
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

            // Load the source image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a zero‑sum edge‑detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the convolution filter with the custom kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    BitDepth = 8
                };

                // Save the processed image
                raster.Save(outputPath, pngOptions);
            }

            // Verify that the background is near‑black by computing average RGB intensity
            using (Image resultImage = Image.Load(outputPath))
            {
                RasterImage resultRaster = (RasterImage)resultImage;
                int width = resultRaster.Width;
                int height = resultRaster.Height;

                // Load ARGB pixel data
                int[] pixels = resultRaster.LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                long sum = 0;
                foreach (int argb in pixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    sum += r + g + b;
                }

                double averageIntensity = sum / (double)(pixels.Length * 3);
                Console.WriteLine($"Average RGB intensity after edge detection: {averageIntensity:F2}");
                // An average close to 0 indicates a near‑black background.
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
 * 1. When you need to highlight edges in a PNG image while keeping the surrounding background nearly black for visual emphasis.
 * 2. When you want to apply a custom zero‑sum convolution kernel in C# with Aspose.Imaging to perform edge detection.
 * 3. When you must save the processed image as a true‑color PNG with alpha channel and 8‑bit depth.
 * 4. When you require automatic verification that the output image’s background is near‑black by computing average RGB intensity.
 * 5. When you are creating an automated image‑processing workflow that applies edge detection and validates the result programmatically.
 */
