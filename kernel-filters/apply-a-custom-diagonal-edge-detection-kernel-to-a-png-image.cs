// HOW-TO: Apply Custom Diagonal Edge Detection Kernel to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "./input.png";
            string outputPath = "./output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                var bounds = raster.Bounds;

                int[] pixels = raster.LoadArgb32Pixels(bounds);
                int[] result = new int[pixels.Length];

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                int kSize = 3;
                int kOffset = kSize / 2;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = y * width + x;

                        if (x < kOffset || x >= width - kOffset || y < kOffset || y >= height - kOffset)
                        {
                            result[idx] = pixels[idx];
                            continue;
                        }

                        double sumA = 0, sumR = 0, sumG = 0, sumB = 0;

                        for (int ky = 0; ky < kSize; ky++)
                        {
                            for (int kx = 0; kx < kSize; kx++)
                            {
                                int neighborX = x + kx - kOffset;
                                int neighborY = y + ky - kOffset;
                                int nIdx = neighborY * width + neighborX;
                                int pixel = pixels[nIdx];

                                int a = (pixel >> 24) & 0xFF;
                                int r = (pixel >> 16) & 0xFF;
                                int g = (pixel >> 8) & 0xFF;
                                int b = pixel & 0xFF;

                                double k = kernel[ky, kx];

                                sumA += a * k;
                                sumR += r * k;
                                sumG += g * k;
                                sumB += b * k;
                            }
                        }

                        int aRes = (int)Math.Round(sumA);
                        int rRes = (int)Math.Round(sumR);
                        int gRes = (int)Math.Round(sumG);
                        int bRes = (int)Math.Round(sumB);

                        aRes = Math.Max(0, Math.Min(255, aRes));
                        rRes = Math.Max(0, Math.Min(255, rRes));
                        gRes = Math.Max(0, Math.Min(255, gRes));
                        bRes = Math.Max(0, Math.Min(255, bRes));

                        result[idx] = (aRes << 24) | (rRes << 16) | (gRes << 8) | bRes;
                    }
                }

                raster.SaveArgb32Pixels(bounds, result);
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight edges in a PNG photograph for computer‑vision preprocessing using Aspose.Imaging in a C# application.
 * 2. When you want to create a stylized outline effect on product images before uploading them to an e‑commerce site.
 * 3. When you must detect structural features in scanned engineering drawings by applying a custom convolution kernel in .NET.
 * 4. When you are building a medical‑imaging tool that requires edge enhancement of PNG X‑ray images for better diagnosis.
 * 5. When you need to automate batch processing of PNG assets to generate edge‑detected versions for a game’s visual effects pipeline.
 */
