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
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image using Aspose.Imaging's constructor rule
        using (PngImage image = new PngImage(inputPath))
        {
            int width = image.Width;
            int height = image.Height;

            // Create a copy of pixel data to read original values while writing new ones
            Color[,] originalPixels = new Color[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    originalPixels[x, y] = image.GetPixel(x, y);
                }
            }

            // Define a zero‑sum edge‑detection kernel (Laplacian)
            int[,] kernel = new int[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            int kSize = 3;
            int kOffset = kSize / 2;

            // Apply the kernel (skip border pixels)
            for (int y = kOffset; y < height - kOffset; y++)
            {
                for (int x = kOffset; x < width - kOffset; x++)
                {
                    int sum = 0;
                    for (int ky = -kOffset; ky <= kOffset; ky++)
                    {
                        for (int kx = -kOffset; kx <= kOffset; kx++)
                        {
                            Color srcColor = originalPixels[x + kx, y + ky];
                            // Convert to grayscale intensity using luminance formula
                            int intensity = (int)(0.299 * srcColor.R + 0.587 * srcColor.G + 0.114 * srcColor.B);
                            sum += intensity * kernel[ky + kOffset, kx + kOffset];
                        }
                    }

                    // Clamp result to byte range
                    sum = Math.Max(0, Math.Min(255, sum));

                    // Set the new pixel (grayscale)
                    Color newColor = Color.FromArgb(sum, sum, sum);
                    image.SetPixel(x, y, newColor);
                }
            }

            // Save the processed image using Aspose.Imaging's Save rule
            image.Save(outputPath);
        }
    }
}