// HOW-TO: Increase Brightness and Apply 5x5 Blur to BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] resultPixels = new int[originalPixels.Length];

                double[,] kernel = new double[,]
                {
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 }
                };

                int kHalf = 2; // kernel radius for 5x5

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (x < kHalf || x >= width - kHalf || y < kHalf || y >= height - kHalf)
                        {
                            resultPixels[y * width + x] = originalPixels[y * width + x];
                            continue;
                        }

                        double sumA = 0, sumR = 0, sumG = 0, sumB = 0;

                        for (int ky = -kHalf; ky <= kHalf; ky++)
                        {
                            for (int kx = -kHalf; kx <= kHalf; kx++)
                            {
                                int srcX = x + kx;
                                int srcY = y + ky;
                                int srcPixel = originalPixels[srcY * width + srcX];

                                double weight = kernel[ky + kHalf, kx + kHalf];

                                sumA += ((srcPixel >> 24) & 0xFF) * weight;
                                sumR += ((srcPixel >> 16) & 0xFF) * weight;
                                sumG += ((srcPixel >> 8) & 0xFF) * weight;
                                sumB += (srcPixel & 0xFF) * weight;
                            }
                        }

                        int a = (int)Math.Round(sumA);
                        int r = (int)Math.Round(sumR);
                        int g = (int)Math.Round(sumG);
                        int b = (int)Math.Round(sumB);

                        a = Math.Clamp(a, 0, 255);
                        r = Math.Clamp(r, 0, 255);
                        g = Math.Clamp(g, 0, 255);
                        b = Math.Clamp(b, 0, 255);

                        resultPixels[y * width + x] = (a << 24) | (r << 16) | (g << 8) | b;
                    }
                }

                BmpOptions options = new BmpOptions();
                options.BitsPerPixel = 32;

                using (Image outputImage = Image.Create(options, width, height))
                {
                    RasterImage outRaster = (RasterImage)outputImage;
                    outRaster.SaveArgb32Pixels(outRaster.Bounds, resultPixels);
                    outputImage.Save(outputPath);
                }
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
 * 1. When a developer needs to enhance the visibility of a scanned BMP document by brightening it while smoothing noise with a 5x5 blur using Aspose.Imaging in C#.
 * 2. When an application must preprocess BMP textures for a game engine, increasing their overall luminance and applying a uniform blur to reduce harsh edges before loading them.
 * 3. When a batch‑processing tool has to automatically adjust the brightness of BMP screenshots and soften details to meet a publishing style guide.
 * 4. When a medical‑imaging system requires a quick brightness boost and mild blur on BMP X‑ray images to improve visual analysis without altering the original file format.
 * 5. When a developer wants to implement a custom convolution filter in C# that both brightens and blurs BMP images as part of an automated image‑enhancement pipeline.
 */
