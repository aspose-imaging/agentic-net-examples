// HOW-TO: Draw a Floating Point Rectangle on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions options = new BmpOptions();
            options.BitsPerPixel = 24;
            options.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(options, 300, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                RectangleF rect = new RectangleF(10.5f, 20.5f, 150.75f, 80.25f);
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, rect);
                image.Save();
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
 * 1. When you need to generate a BMP diagram that highlights a specific area with a precisely positioned rectangle using floating‑point coordinates.
 * 2. When creating programmatic image annotations for engineering schematics where the rectangle dimensions must be defined with sub‑pixel accuracy.
 * 3. When building a C# application that overlays a blue border on a white background BMP to mark selection zones in a custom UI.
 * 4. When exporting chart or map screenshots to BMP format and require exact rectangle overlays for data‑range visualization.
 * 5. When automating the production of printable assets that need a high‑resolution rectangle drawn at non‑integer positions for alignment testing.
 */
