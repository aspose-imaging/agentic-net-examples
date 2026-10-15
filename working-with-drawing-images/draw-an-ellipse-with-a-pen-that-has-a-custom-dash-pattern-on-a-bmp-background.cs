// HOW-TO: Draw Dashed Ellipse on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.LightGray);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 3);
                pen.DashPattern = new float[] { 5, 2 };

                Rectangle rect = new Rectangle(50, 50, 300, 200);
                graphics.DrawEllipse(pen, rect);

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
 * 1. When you need to generate a BMP diagram that highlights a region with a dashed‑style ellipse for a technical report.
 * 2. When creating a custom UI thumbnail where a blue, dashed outline indicates a selectable area on a light‑gray background.
 * 3. When programmatically adding a stylized annotation to scanned BMP documents, such as marking defects with a patterned ellipse.
 * 4. When exporting chart graphics from a C# application and requiring a non‑solid ellipse border to differentiate data series.
 * 5. When automating the production of printable assets that need a specific dash pattern on vector shapes within a BMP file.
 */
