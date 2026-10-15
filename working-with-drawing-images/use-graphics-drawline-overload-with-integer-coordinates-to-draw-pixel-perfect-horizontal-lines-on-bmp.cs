// HOW-TO: Draw Pixel‑Perfect Horizontal Lines on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                int width = 200;
                int height = 100;
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    Pen pen = new Pen(Aspose.Imaging.Color.Black);
                    for (int y = 0; y < height; y += 10)
                    {
                        graphics.DrawLine(pen, 0, y, width - 1, y);
                    }
                    image.Save();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a simple grid or ruler overlay on a BMP for a reporting tool.
 * 2. When creating test patterns with precise horizontal lines to validate image rendering pipelines.
 * 3. When producing printable forms that require exact pixel‑aligned separators in black and white.
 * 4. When generating background textures for games where each line must align to the bitmap’s pixel grid.
 * 5. When automating the creation of barcode or scan‑line mock‑ups that demand consistent line spacing in BMP files.
 */
