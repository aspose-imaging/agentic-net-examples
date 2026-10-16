// HOW-TO: Draw a Bezier Curve on a BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new StreamSource(new MemoryStream())
            };

            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);

                var pen = new Pen(Color.Blue, 2);

                var p1 = new Point(10, 150);
                var p2 = new Point(50, 10);
                var p3 = new Point(150, 10);
                var p4 = new Point(190, 150);

                graphics.DrawBezier(pen, p1, p2, p3, p4);

                image.Save(outputPath);
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
 * 1. When you need to generate a custom BMP graphic with a smooth blue Bezier curve over a yellow background using Aspose.Imaging in C#.
 * 2. When creating dynamic icons or UI elements in a Windows desktop application that require precise curve drawing with Point structures.
 * 3. When producing test images for computer‑vision algorithms that need known geometric shapes such as a Bezier path rendered to a 24‑bit BMP file.
 * 4. When exporting vector‑style illustrations to raster BMP files for legacy systems that only support 24‑bit bitmaps and require exact control‑point placement.
 * 5. When automating the creation of diagrammatic schematics where control points must be defined explicitly for accurate curve rendering with Aspose.Imaging.
 */
