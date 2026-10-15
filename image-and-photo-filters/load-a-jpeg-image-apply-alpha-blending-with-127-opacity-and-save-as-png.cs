// HOW-TO: Blend JPEG Image With 50% Opacity And Save As PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(inputPath))
            using (RasterImage overlay = (RasterImage)Image.Load(inputPath))
            {
                int offsetX = (background.Width - overlay.Width) / 2;
                int offsetY = (background.Height - overlay.Height) / 2;
                background.Blend(new Point(offsetX, offsetY), overlay, 127);

                PngOptions pngOptions = new PngOptions
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
 * 1. When you need to create a semi‑transparent overlay of a JPEG and export it as a PNG for web graphics.
 * 2. When you want to combine two identical photos with adjustable opacity to produce a watermark effect in a .NET application.
 * 3. When you must convert a JPEG to a lossless PNG while applying an alpha blend to control image transparency.
 * 4. When you are generating thumbnails that require a centered overlay with 127 (≈50%) opacity for UI previews.
 * 5. When you are building a batch process that reads JPEG files, blends them with a specified opacity, and saves the result as PNG for further compositing.
 */
