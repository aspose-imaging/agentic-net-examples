// HOW-TO: Create 800x600 PNG With Red Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
        try
        {
            string outputPath = "output/ellipse.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Red);
                graphics.DrawEllipse(pen, new Rectangle(0, 0, 800, 600));

                canvas.Save();
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
 * 1. When you need to generate a blank PNG image of a specific size and draw a red ellipse for a dynamic chart or placeholder graphic.
 * 2. When creating server‑side graphics for reports, such as a red circular badge that fits an 800×600 canvas.
 * 3. When automating the production of custom icons or logos that require a red ellipse drawn programmatically in C#.
 * 4. When building a web service that returns a PNG with a red ellipse as a visual cue for image‑processing pipelines.
 * 5. When testing image‑rendering code by programmatically creating a known PNG file containing a red ellipse for verification.
 */
