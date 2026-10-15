// HOW-TO: Draw an S‑Shaped Bezier Curve on a BMP with C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                PointF p0 = new PointF(50, 250);
                PointF p1 = new PointF(150, 50);
                PointF p2 = new PointF(250, 250);
                PointF p3 = new PointF(350, 50);
                graphics.DrawBezier(pen, p0, p1, p2, p3);
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
 * 1. When you need to generate a BMP file with a custom S‑shaped line for diagrams or UI mock‑ups programmatically in C#.
 * 2. When you want to create smooth vector‑based curves in raster images for scientific plots or engineering schematics using Aspose.Imaging.
 * 3. When an application must render decorative separators or wave patterns on bitmap assets without relying on external design tools.
 * 4. When you are automating the production of test images that contain precise Bezier paths to validate image‑processing algorithms.
 * 5. When you need to embed dynamically generated curved graphics into reports or PDFs that later reference the BMP as a source image.
 */
