// HOW-TO: Normalize Custom Convolution Kernel and Apply to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                double[,] kernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1,  1, 1 },
                    {  0,  1, 2 }
                };

                double sum = 0;
                foreach (double v in kernel) sum += v;
                if (sum != 0)
                {
                    int rows = kernel.GetLength(0);
                    int cols = kernel.GetLength(1);
                    for (int i = 0; i < rows; i++)
                        for (int j = 0; j < cols; j++)
                            kernel[i, j] /= sum;
                }

                int kHeight = kernel.GetLength(0);
                int kWidth = kernel.GetLength(1);
                int kHalfH = kHeight / 2;
                int kHalfW = kWidth / 2;

                int[] srcPixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, width, height));
                int[] dstPixels = new int[width * height];
                Array.Copy(srcPixels, dstPixels, srcPixels.Length);

                for (int y = kHalfH; y < height - kHalfH; y++)
                {
                    for (int x = kHalfW; x < width - kHalfW; x++)
                    {
                        double aSum = 0, rSum = 0, gSum = 0, bSum = 0;

                        for (int ky = 0; ky < kHeight; ky++)
                        {
                            int ny = y + ky - kHalfH;
                            for (int kx = 0; kx < kWidth; kx++)
                            {
                                int nx = x + kx - kHalfW;
                                int pixel = srcPixels[ny * width + nx];
                                double coeff = kernel[ky, kx];

                                int a = (pixel >> 24) & 0xFF;
                                int r = (pixel >> 16) & 0xFF;
                                int g = (pixel >> 8) & 0xFF;
                                int b = pixel & 0xFF;

                                aSum += a * coeff;
                                rSum += r * coeff;
                                gSum += g * coeff;
                                bSum += b * coeff;
                            }
                        }

                        int aOut = Math.Clamp((int)Math.Round(aSum), 0, 255);
                        int rOut = Math.Clamp((int)Math.Round(rSum), 0, 255);
                        int gOut = Math.Clamp((int)Math.Round(gSum), 0, 255);
                        int bOut = Math.Clamp((int)Math.Round(bSum), 0, 255);

                        dstPixels[y * width + x] = (aOut << 24) | (rOut << 16) | (gOut << 8) | bOut;
                    }
                }

                raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), dstPixels);

                JpegOptions jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to apply a custom edge‑detecting filter to a JPEG before saving it.
 * 2. When you must ensure a user‑defined convolution matrix is normalized so the image brightness stays consistent.
 * 3. When processing large batches of photos and you want to embed a custom sharpening kernel directly in C# code.
 * 4. When you need to programmatically adjust pixel values of a JPEG using a 3×3 kernel for computer‑vision preprocessing.
 * 5. When you want to replace built‑in filters with a bespoke kernel while preserving the original image dimensions and format.
 */
