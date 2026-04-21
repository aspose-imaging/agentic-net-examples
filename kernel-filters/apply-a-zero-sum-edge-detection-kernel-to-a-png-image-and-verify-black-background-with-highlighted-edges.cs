using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage image = new PngImage(inputPath))
        {
            int width = image.Width;
            int height = image.Height;
            var bounds = image.Bounds;

            // Load all ARGB32 pixels
            int[] srcPixels = image.LoadArgb32Pixels(bounds);
            int[] dstPixels = new int[srcPixels.Length];

            // Zero‑sum edge detection kernel (Laplacian)
            int[,] kernel = new int[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply convolution (skip border pixels)
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int sum = 0;
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            int srcIndex = (y + ky) * width + (x + kx);
                            int argb = srcPixels[srcIndex];

                            // Extract RGB components
                            int r = (argb >> 16) & 0xFF;
                            int g = (argb >> 8) & 0xFF;
                            int b = argb & 0xFF;

                            // Simple intensity (grayscale) value
                            int intensity = (r + g + b) / 3;

                            int k = kernel[ky + 1, kx + 1];
                            sum += intensity * k;
                        }
                    }

                    // Absolute value and clamp to [0,255]
                    int v = Math.Abs(sum);
                    if (v > 255) v = 255;

                    // Construct ARGB pixel (opaque)
                    int dstArgb = (255 << 24) | (v << 16) | (v << 8) | v;
                    dstPixels[y * width + x] = dstArgb;
                }
            }

            // Set border pixels to black
            for (int x = 0; x < width; x++)
            {
                dstPixels[x] = 0; // top row
                dstPixels[(height - 1) * width + x] = 0; // bottom row
            }
            for (int y = 0; y < height; y++)
            {
                dstPixels[y * width] = 0; // left column
                dstPixels[y * width + (width - 1)] = 0; // right column
            }

            // Write processed pixels back to the image
            image.SaveArgb32Pixels(bounds, dstPixels);

            // Save the result
            image.Save(outputPath);
        }
    }
}