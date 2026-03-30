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
        string outputPath = @"C:\Images\output_edges.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source PNG image
        using (PngImage sourceImage = new PngImage(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Load all ARGB pixels from the source image
            int[] srcPixels = sourceImage.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height));

            // Prepare destination pixel buffer
            int[] destPixels = new int[width * height];

            // Zero‑sum edge detection kernel (3x3)
            int[,] kernel = new int[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            int kSize = 3;
            int kOffset = kSize / 2;

            // Apply convolution
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int sum = 0;

                    for (int ky = 0; ky < kSize; ky++)
                    {
                        int py = y + ky - kOffset;
                        if (py < 0 || py >= height) continue;

                        for (int kx = 0; kx < kSize; kx++)
                        {
                            int px = x + kx - kOffset;
                            if (px < 0 || px >= width) continue;

                            int pixel = srcPixels[py * width + px];

                            // Convert pixel to grayscale intensity using luminance formula
                            int r = (pixel >> 16) & 0xFF;
                            int g = (pixel >> 8) & 0xFF;
                            int b = pixel & 0xFF;
                            int intensity = (r * 299 + g * 587 + b * 114) / 1000;

                            sum += intensity * kernel[ky, kx];
                        }
                    }

                    // Clamp result to [0,255]
                    sum = Math.Max(0, Math.Min(255, sum));

                    // Build ARGB pixel (opaque)
                    destPixels[y * width + x] = (255 << 24) | (sum << 16) | (sum << 8) | sum;
                }
            }

            // Create a new PNG image for the result
            using (PngImage resultImage = new PngImage(width, height))
            {
                // Write processed pixels
                resultImage.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), destPixels);

                // Save the result image
                resultImage.Save(outputPath);
            }
        }
    }
}