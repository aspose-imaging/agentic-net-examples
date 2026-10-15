// HOW-TO: Convert ODG to BMP and Apply Threshold Filter in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, new BmpOptions());
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        int width = raster.Width;
                        int height = raster.Height;
                        int[] pixels = new int[width * height];

                        raster.SaveArgb32Pixels(raster.Bounds, pixels);

                        const int threshold = 128;
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int a = (pixels[i] >> 24) & 0xFF;
                            int r = (pixels[i] >> 16) & 0xFF;
                            int g = (pixels[i] >> 8) & 0xFF;
                            int b = pixels[i] & 0xFF;
                            int intensity = (r + g + b) / 3;
                            int bw = intensity >= threshold ? 255 : 0;
                            pixels[i] = (a << 24) | (bw << 16) | (bw << 8) | bw;
                        }

                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int x = i % width;
                            int y = i / width;
                            int argb = pixels[i];
                            Aspose.Imaging.Color color = Aspose.Imaging.Color.FromArgb(
                                (argb >> 24) & 0xFF,
                                (argb >> 16) & 0xFF,
                                (argb >> 8) & 0xFF,
                                argb & 0xFF);
                            raster.SetPixel(x, y, color);
                        }

                        raster.Save(outputPath, new BmpOptions());
                    }
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
 * 1. When you need to render an OpenDocument Graphics (ODG) diagram as a black‑and‑white BMP for legacy Windows applications that only accept bitmap input.
 * 2. When preparing vector drawings for OCR, converting ODG to BMP and applying a threshold creates a high‑contrast binary image that improves text recognition accuracy.
 * 3. When generating printable line art from ODG files, converting to BMP and binarizing ensures consistent ink coverage on monochrome printers.
 * 4. When building a document‑conversion pipeline that extracts vector graphics from ODG and stores them as compact BMP files with a simple binary mask for storage or transmission.
 * 5. When creating thumbnails for a web gallery that require fast loading, converting ODG to a small BMP and applying a threshold reduces file size and simplifies client‑side rendering.
 */
