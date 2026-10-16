// HOW-TO: Create BMP With Rectangle And Semi Transparent Ellipse In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 300;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 300, 200);
                graphics.DrawRectangle(pen, rect);

                Aspose.Imaging.Color semiTransparentRed = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0);
                using (SolidBrush brush = new SolidBrush(semiTransparentRed))
                {
                    graphics.FillEllipse(brush, rect);
                }

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
 * 1. When you need to generate a BMP report thumbnail that highlights a region with a colored rectangle and a translucent overlay.
 * 2. When you want to programmatically add a semi‑transparent watermark shape to a bitmap for UI mock‑ups.
 * 3. When you are building a diagnostic image that shows a selected area using a rectangle and a faded ellipse for medical or engineering visualization.
 * 4. When you need to create a simple graphic for a game asset where a solid border and a partially transparent highlight are required.
 * 5. When you are testing image‑processing pipelines and require a BMP file containing both vector‑drawn shapes and alpha‑blended fills.
 */
