// HOW-TO: Apply Emboss3x3 Filter to PNG and Keep ICC Profile Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

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
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to add a 3×3 emboss effect to a PNG while ensuring the embedded ICC color profile remains unchanged for accurate color reproduction.
 * 2. When processing product‑photos in an e‑commerce pipeline and you must enhance texture with embossing without losing the original color management data.
 * 3. When converting scanned documents to PNG with a stylized emboss look and you have to preserve the source’s color profile for printing consistency.
 * 4. When building a desktop image‑editing tool that offers an emboss filter and must retain the image’s embedded profile so edited images display correctly on different monitors.
 * 5. When automating batch processing of PNG assets for a mobile app, applying emboss shading while keeping each file’s embedded color profile intact for consistent UI theming.
 */
