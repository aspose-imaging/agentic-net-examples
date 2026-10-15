// HOW-TO: Convert PNG to SVG with 16‑Color Palette Reduction in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 16);

                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_reduced.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette,
                    PngCompressionLevel = PngCompressionLevel.ZipLevel6
                };
                raster.Save(tempPngPath, pngOptions);

                using (Image reduced = Image.Load(tempPngPath))
                {
                    SvgOptions svgOptions = new SvgOptions();
                    reduced.Save(outputPath, svgOptions);
                }

                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to shrink a high‑resolution PNG for faster web loading while keeping it scalable as an SVG with only 16 colors.
 * 2. When creating icon sets that must be vector‑based for UI design but must adhere to a limited color palette for brand consistency.
 * 3. When preparing graphics for low‑bandwidth mobile applications where a reduced palette and vector format minimize data usage.
 * 4. When converting raster logos to SVG for print or signage while ensuring the file size stays small by limiting colors to 16.
 * 5. When generating SVG assets from PNG screenshots for documentation, and you want to preserve visual fidelity with a compact indexed‑color palette.
 */
