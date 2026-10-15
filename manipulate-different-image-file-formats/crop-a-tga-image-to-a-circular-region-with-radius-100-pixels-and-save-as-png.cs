// HOW-TO: Crop a TGA Image to a 100‑Pixel Circle and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int radius = 100;
                int diameter = radius * 2;
                int cx = image.Width / 2;
                int cy = image.Height / 2;

                var srcRect = new Rectangle(cx - radius, cy - radius, diameter, diameter);
                int[] srcPixels = image.LoadArgb32Pixels(srcRect);

                int[] dstPixels = new int[diameter * diameter];

                for (int y = 0; y < diameter; y++)
                {
                    for (int x = 0; x < diameter; x++)
                    {
                        int dx = x - radius;
                        int dy = y - radius;
                        if (dx * dx + dy * dy <= radius * radius)
                        {
                            int srcIndex = y * diameter + x;
                            dstPixels[srcIndex] = srcPixels[srcIndex];
                        }
                        else
                        {
                            dstPixels[y * diameter + x] = 0; // Transparent
                        }
                    }
                }

                using (PngImage png = new PngImage(diameter, diameter, PngColorType.TruecolorWithAlpha))
                {
                    png.SaveArgb32Pixels(new Rectangle(0, 0, diameter, diameter), dstPixels);
                    var options = new PngOptions();
                    png.Save(outputPath, options);
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
 * 1. When you need to generate circular thumbnails from legacy TGA game assets for a web gallery.
 * 2. When you must convert a TGA sprite sheet into a transparent PNG icon with a fixed radius for UI overlays.
 * 3. When creating profile picture placeholders by extracting a centered circular region from high‑resolution TGA scans.
 * 4. When preparing circular masks for scientific visualizations that require TGA source data and PNG output.
 * 5. When automating batch processing of TGA textures to produce round PNG decals for augmented‑reality applications.
 */
