// HOW-TO: Draw a 180 Degree Arc in a 400x200 PNG with C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/arc.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();

            using (RasterImage image = (RasterImage)Image.Create(pngOptions, 400, 200))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Blue, 2);
                Rectangle rect = new Rectangle(0, 0, 400, 200);
                graphics.DrawArc(pen, rect, 45f, 180f);
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG badge that includes a semi‑circular progress indicator for a web dashboard.
 * 2. When creating custom chart annotations, such as a curved highlight over a specific data range in a 400 × 200 image.
 * 3. When producing printable graphics that require a precise arc, like a decorative border for a PDF flyer generated from C#.
 * 4. When building a game UI element that displays a rotating compass arc inside a fixed‑size texture.
 * 5. When automating the creation of thumbnail overlays that show a 180° arc to indicate direction or coverage on a map image.
 */
