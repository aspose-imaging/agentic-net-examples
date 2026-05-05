using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load PNG as RasterImage
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                var rect = new Rectangle(0, 0, width, height);

                // Load ARGB pixels
                int[] originalPixels = raster.LoadArgb32Pixels(rect);
                int[] processedPixels = new int[originalPixels.Length];

                // Define a 3x3 sharpening kernel
                double[,] kernel = new double[3, 3]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };
                int kSize = 3;
                int kHalf = kSize / 2;

                // Helper to clamp channel values to 0‑255
                int Clamp(int value) => value < 0 ? 0 : (value > 255 ? 255 : value);

                // Apply convolution (skip borders)
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // For border pixels, copy original
                        if (x < kHalf || x >= width - kHalf || y < kHalf || y >= height - kHalf)
                        {
                            processedPixels[y * width + x] = originalPixels[y * width + x];
                            continue;
                        }

                        int sumA = 0, sumR = 0, sumG = 0, sumB = 0;

                        for (int ky = 0; ky < kSize; ky++)
                        {
                            for (int kx = 0; kx < kSize; kx++)
                            {
                                int srcX = x + kx - kHalf;
                                int srcY = y + ky - kHalf;
                                int pixel = originalPixels[srcY * width + srcX];

                                int a = (pixel >> 24) & 0xFF;
                                int r = (pixel >> 16) & 0xFF;
                                int g = (pixel >> 8) & 0xFF;
                                int b = pixel & 0xFF;

                                double coeff = kernel[ky, kx];

                                sumA += (int)(a * coeff);
                                sumR += (int)(r * coeff);
                                sumG += (int)(g * coeff);
                                sumB += (int)(b * coeff);
                            }
                        }

                        // Clamp each channel to 0‑255
                        int aClamped = Clamp(sumA);
                        int rClamped = Clamp(sumR);
                        int gClamped = Clamp(sumG);
                        int bClamped = Clamp(sumB);

                        processedPixels[y * width + x] = (aClamped << 24) | (rClamped << 16) | (gClamped << 8) | bClamped;
                    }
                }

                // Save the modified pixels back to the image
                raster.SaveArgb32Pixels(rect, processedPixels);

                // Prepare PNG save options
                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the image
                raster.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}