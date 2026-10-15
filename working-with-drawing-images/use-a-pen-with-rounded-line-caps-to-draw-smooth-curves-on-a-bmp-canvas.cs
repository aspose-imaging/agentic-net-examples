// HOW-TO: Draw Smooth Bezier Curve on BMP with Rounded Caps in C# (Aspose.Imaging for .NET)
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

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 5);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                PointF p1 = new PointF(50, 250);
                PointF p2 = new PointF(150, 50);
                PointF p3 = new PointF(250, 450);
                PointF p4 = new PointF(350, 150);

                graphics.DrawBezier(pen, p1, p2, p3, p4);

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
 * 1. When you need to generate a BMP diagram with smooth curved lines for a technical report.
 * 2. When creating custom icons or UI assets that require anti‑aliased Bezier strokes with rounded ends.
 * 3. When programmatically adding decorative curves to scanned documents before saving them as BMP files.
 * 4. When building a server‑side service that produces thumbnail previews with stylized curves for a web application.
 * 5. When automating the production of printable graphics, such as signage or labels, that need precise BMP output with consistent line caps.
 */
