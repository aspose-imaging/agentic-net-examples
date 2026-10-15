// HOW-TO: Create BMP Image with Blue Diagonal Line in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Create(new BmpOptions() { Source = new FileCreateSource(outputPath, false) }, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Point start = new Point(20, 20);
                Point end = new Point(180, 180);
                Pen pen = new Pen(Color.Blue);
                graphics.DrawLine(pen, start, end);

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
 * 1. When you need to programmatically generate a placeholder BMP file containing a blue diagonal line for UI mockups or documentation.
 * 2. When you want to add a straight line annotation to a newly created bitmap as part of a reporting or diagramming workflow.
 * 3. When you require test images with known geometric shapes to validate image‑processing algorithms or computer‑vision pipelines.
 * 4. When you need to embed a simple guide line or watermark into a BMP before printing or further processing.
 * 5. When developing a graphics editor that lets users draw basic shapes such as lines on a canvas using Aspose.Imaging in C#.
 */
