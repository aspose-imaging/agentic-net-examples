// HOW-TO: Apply Sharpen Filter with Proper Rounding and Clamping in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, 0, width, height);

                int[] srcPixels = image.GetDefaultArgb32Pixels(bounds);
                int[] dstPixels = new int[srcPixels.Length];

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                int kSize = 3;
                int kHalf = kSize / 2;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = y * width + x;

                        if (x < kHalf || x >= width - kHalf || y < kHalf || y >= height - kHalf)
                        {
                            dstPixels[idx] = srcPixels[idx];
                            continue;
                        }

                        double sumA = 0, sumR = 0, sumG = 0, sumB = 0;

                        for (int ky = -kHalf; ky <= kHalf; ky++)
                        {
                            for (int kx = -kHalf; kx <= kHalf; kx++)
                            {
                                int pixel = srcPixels[(y + ky) * width + (x + kx)];
                                double coeff = kernel[ky + kHalf, kx + kHalf];

                                int a = (pixel >> 24) & 0xFF;
                                int r = (pixel >> 16) & 0xFF;
                                int g = (pixel >> 8) & 0xFF;
                                int b = pixel & 0xFF;

                                sumA += coeff * a;
                                sumR += coeff * r;
                                sumG += coeff * g;
                                sumB += coeff * b;
                            }
                        }

                        int aNew = (int)Math.Round(sumA);
                        int rNew = (int)Math.Round(sumR);
                        int gNew = (int)Math.Round(sumG);
                        int bNew = (int)Math.Round(sumB);

                        aNew = Math.Max(0, Math.Min(255, aNew));
                        rNew = Math.Max(0, Math.Min(255, rNew));
                        gNew = Math.Max(0, Math.Min(255, gNew));
                        bNew = Math.Max(0, Math.Min(255, bNew));

                        dstPixels[idx] = (aNew << 24) | (rNew << 16) | (gNew << 8) | bNew;
                    }
                }

                image.SaveArgb32Pixels(bounds, dstPixels);
                PngOptions options = new PngOptions();
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
 * 1. When you need to sharpen a PNG image in a .NET application while ensuring pixel values are accurately rounded before being limited to the 0‑255 range.
 * 2. When processing large batches of raster images and you must apply a custom 3×3 convolution kernel without introducing color distortion due to improper rounding.
 * 3. When building a photo‑editing tool that uses Aspose.Imaging to enhance image contrast and you want the output to retain correct ARGB values after the filter.
 * 4. When converting raw pixel data to a new image after applying a sharpening mask and you require precise rounding to avoid banding artifacts.
 * 5. When implementing edge‑enhancement for UI thumbnails in C# and need the algorithm to handle border pixels safely while preserving original colors.
 */
