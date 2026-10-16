// HOW-TO: Draw Anti-Aliased Curved Line on BMP Image in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/curved_line.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            int width = 100;
            int height = 100;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Pen pen = new Pen(Color.Blue, 2);
                PointF[] points = new PointF[]
                {
                    new PointF(10, 90),
                    new PointF(50, 10),
                    new PointF(90, 90)
                };
                graphics.DrawCurve(pen, points);

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
 * 1. When you need to generate a high‑quality BMP thumbnail with smooth curved graphics for a Windows desktop application.
 * 2. When creating custom chart markers or decorative elements in a BMP report where anti‑aliased curves improve visual clarity.
 * 3. When exporting hand‑drawn style diagrams to BMP format for printing, and you want the lines to appear without jagged edges.
 * 4. When building a game asset pipeline that programmatically draws smooth paths onto BMP textures using C# and Aspose.Imaging.
 * 5. When automating the creation of BMP icons that contain curved outlines, ensuring the edges are rendered with anti‑aliasing for a professional look.
 */
