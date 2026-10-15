// HOW-TO: Draw Arrow Lines on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output\\arrow.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 5);
                pen.EndCap = LineCap.Triangle;

                graphics.DrawLine(pen, 50, 50, 350, 50);
                graphics.DrawLine(pen, 50, 100, 350, 200);
                graphics.DrawLine(pen, 50, 250, 350, 250);

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
 * 1. When you need to generate a BMP diagram with directional arrows for a technical report using C# and Aspose.Imaging.
 * 2. When you want to programmatically add arrow‑head lines to a bitmap for a custom UI overlay in a Windows application.
 * 3. When you are creating printable schematics that require precise line thickness and triangle end caps on a BMP file.
 * 4. When you need to automate the production of flow‑chart style images where each connector ends with an arrow in a .NET service.
 * 5. When you are building a batch process that draws multiple annotated lines on BMP images for GIS or mapping visualizations.
 */
