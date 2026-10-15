// HOW-TO: Replace Transparent Pixels in PNG with White Background and Save as BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                // Define the solid background color (e.g., opaque white)
                Aspose.Imaging.Color backgroundColor = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Aspose.Imaging.Color pixel = raster.GetPixel(x, y);
                        if (pixel.A < 255) // Transparent or semi‑transparent pixel
                        {
                            raster.SetPixel(x, y, backgroundColor);
                        }
                    }
                }

                BmpOptions bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert a PNG logo that contains semi‑transparent edges into a BMP for use in a legacy Windows application that does not support alpha channels.
 * 2. When preparing product images for printing, you may replace transparent areas with a solid white background before saving them as BMP to ensure consistent background color.
 * 3. When generating thumbnails for a game engine that only accepts BMP files, you can remove transparency from the original PNG and fill it with a chosen color.
 * 4. When batch‑processing user‑uploaded PNG avatars to store them in a database that requires BMP format without transparency, this code fills transparent pixels with a uniform background.
 * 5. When integrating with a third‑party reporting tool that expects BMP images, you can pre‑process PNG charts by substituting transparent pixels with an opaque color to avoid rendering issues.
 */
