// HOW-TO: Create Indexed PSD With 64‑Color Palette From PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.psd";

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

                int[] argbPixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                HashSet<int> uniqueColors = new HashSet<int>();
                foreach (int argb in argbPixels)
                {
                    uniqueColors.Add(argb);
                    if (uniqueColors.Count >= 64)
                        break;
                }

                Color[] paletteColors = new Color[64];
                int index = 0;
                foreach (int argb in uniqueColors)
                {
                    paletteColors[index++] = Color.FromArgb(argb);
                }
                while (index < 64)
                {
                    paletteColors[index++] = Color.Black;
                }

                PsdOptions psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Indexed,
                    Palette = new ColorPalette(paletteColors)
                };

                raster.Save(outputPath, psdOptions);
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
 * 1. When you need to shrink a full‑color PNG into a smaller Photoshop file by converting it to an indexed PSD limited to 64 colors for faster web loading.
 * 2. When preparing graphics for a legacy game engine that only accepts indexed PSD files with a maximum palette of 64 colors.
 * 3. When generating design‑team preview thumbnails that must be PSD format but require a reduced color set to speed up rendering.
 * 4. When converting high‑resolution screenshots into compact PSD files to keep repository sizes low in version‑control systems.
 * 5. When building a batch process that enforces a consistent 64‑color palette across all user‑uploaded images by saving them as indexed PSDs.
 */
