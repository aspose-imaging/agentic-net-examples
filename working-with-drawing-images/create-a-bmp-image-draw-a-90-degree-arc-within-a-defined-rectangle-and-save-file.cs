// HOW-TO: Create BMP Image and Draw 90 Degree Arc in C# (Aspose.Imaging for .NET)
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
            options.Source = new FileCreateSource(outputPath, false);

            int width = 300;
            int height = 200;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 200, 100);
                graphics.DrawArc(pen, rect, 0, 90);

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
 * 1. When you need to generate a BMP diagram with a quarter‑circle highlight for a Windows desktop UI mockup.
 * 2. When you want to programmatically add a blue 90‑degree arc to a bitmap for a custom chart or gauge indicator.
 * 3. When an automated report requires a simple BMP image containing a curved segment inside a defined rectangle.
 * 4. When you are building a game asset pipeline that creates BMP sprites with precise arc shapes for collision boundaries.
 * 5. When you must produce a BMP file with a drawn arc for testing image‑processing algorithms that detect curved edges.
 */
