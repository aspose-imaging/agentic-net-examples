// HOW-TO: Create 500x300 BMP Image With Blue Line Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };
                using (BmpImage canvas = (BmpImage)Image.Create(options, 500, 300))
                {
                    Graphics graphics = new Graphics(canvas);
                    Pen pen = new Pen(Color.Blue, 1);
                    graphics.DrawLine(pen, 50, 50, 450, 250);
                    canvas.Save();
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
 * 1. When you need to generate a BMP placeholder image with a custom line for UI mock‑ups in a .NET application.
 * 2. When creating test assets for automated image‑processing pipelines that require a known size and a simple vector drawing.
 * 3. When producing a simple diagram or schematic programmatically for documentation that must be saved as a BMP file.
 * 4. When dynamically drawing guide lines on a bitmap background for a game level editor built with C#.
 * 5. When exporting a basic line‑art graphic from a server‑side service that uses Aspose.Imaging to support legacy BMP format.
 */
