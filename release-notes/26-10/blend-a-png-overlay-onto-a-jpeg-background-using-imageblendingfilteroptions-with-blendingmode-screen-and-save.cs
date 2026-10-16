// HOW-TO: Blend PNG Overlay onto JPEG Background and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
            string backgroundPath = "background.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output/result.png";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                background.Blend(new Point(0, 0), overlay, 255);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, pngOptions);
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
 * 1. When you need to add a transparent logo or watermark PNG on top of a photographic JPEG and output a lossless PNG for web use.
 * 2. When creating product mock‑ups that combine a high‑resolution JPEG product shot with a PNG design overlay in a C# application.
 * 3. When generating composite images for marketing emails by programmatically blending a PNG badge onto a JPEG background using Aspose.Imaging.
 * 4. When converting a JPEG banner to a PNG format while preserving an overlay graphic for further editing or printing.
 * 5. When automating the creation of social‑media graphics that require a PNG overlay to be merged with a JPEG photo before publishing.
 */
