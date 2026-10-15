// HOW-TO: Convert EPS To Optimized 256‑Color PNG In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output\\optimized.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to embed a vector logo from an EPS file into a website and want a small PNG with a limited 256‑color palette for faster loading.
 * 2. When you are generating email newsletters and must convert high‑resolution EPS graphics to low‑size PNGs that comply with email client size limits.
 * 3. When a mobile app requires PNG assets with indexed colors to reduce memory usage, and you have the source artwork in EPS format.
 * 4. When creating printable PDFs that reference PNG previews, you can convert EPS diagrams to 256‑color PNGs to keep the preview file size minimal.
 * 5. When building a batch processing tool that prepares assets for a content management system, you can use this code to automatically reduce EPS files to optimized PNGs with a fixed palette.
 */
