// HOW-TO: Sharpen PNG Image with Convolution and Proper Rounding in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input\\input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int width = image.Width;
                int height = image.Height;
                int[] originalPixels = new int[width * height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        originalPixels[y * width + x] = image.GetArgb32Pixel(x, y);
                    }
                }

                int[] resultPixels = new int[originalPixels.Length];
                Array.Copy(originalPixels, resultPixels, originalPixels.Length);

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                int kSize = 3;
                int kOffset = kSize / 2;

                for (int y = kOffset; y < height - kOffset; y++)
                {
                    for (int x = kOffset; x < width - kOffset; x++)
                    {
                        double sumR = 0, sumG = 0, sumB = 0;
                        for (int ky = -kOffset; ky <= kOffset; ky++)
                        {
                            for (int kx = -kOffset; kx <= kOffset; kx++)
                            {
                                int pixelX = x + kx;
                                int pixelY = y + ky;
                                int idx = pixelY * width + pixelX;
                                int argb = originalPixels[idx];
                                int r = (argb >> 16) & 0xFF;
                                int g = (argb >> 8) & 0xFF;
                                int b = argb & 0xFF;
                                double kVal = kernel[ky + kOffset, kx + kOffset];
                                sumR += r * kVal;
                                sumG += g * kVal;
                                sumB += b * kVal;
                            }
                        }

                        int a = (originalPixels[y * width + x] >> 24) & 0xFF;
                        int newR = (int)Math.Round(sumR);
                        int newG = (int)Math.Round(sumG);
                        int newB = (int)Math.Round(sumB);

                        newR = Math.Max(0, Math.Min(255, newR));
                        newG = Math.Max(0, Math.Min(255, newG));
                        newB = Math.Max(0, Math.Min(255, newB));

                        int newArgb = (a << 24) | (newR << 16) | (newG << 8) | newB;
                        resultPixels[y * width + x] = newArgb;
                    }
                }

                Rectangle rect = new Rectangle(0, 0, width, height);
                image.SaveArgb32Pixels(rect, resultPixels);
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
 * 1. When you need to enhance the details of a PNG photograph by applying a custom sharpening kernel while ensuring pixel values are correctly rounded before being limited to the 0‑255 range.
 * 2. When you want to preprocess scanned documents in C# to improve readability, using Aspose.Imaging to apply a convolution filter that sharpens edges without introducing color distortion.
 * 3. When building an automated batch‑processing tool that reads PNG files, applies a 3×3 sharpening matrix, and saves the results with accurate color values for downstream computer‑vision tasks.
 * 4. When integrating image‑enhancement functionality into a .NET web service that must cache raster data, perform convolution, and guarantee that the output pixels remain valid ARGB values.
 * 5. When creating a desktop application that lets users fine‑tune image clarity by modifying kernel coefficients, and you need to round intermediate convolution sums to avoid overflow before clamping.
 */
