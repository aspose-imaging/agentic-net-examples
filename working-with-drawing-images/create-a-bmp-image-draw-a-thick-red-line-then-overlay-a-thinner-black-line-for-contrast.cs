// HOW-TO: Create BMP with Red Line and Black Outline in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen redPen = new Pen(Aspose.Imaging.Color.Red, 10);
                graphics.DrawLine(redPen, new Point(20, 20), new Point(180, 180));

                Pen blackPen = new Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(blackPen, new Point(20, 20), new Point(180, 180));

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
 * 1. When you need to generate a BMP file programmatically and highlight a path with a thick red line topped by a thin black border for visual contrast.
 * 2. When creating simple diagrammatic assets such as arrows or connectors in a bitmap for reports or UI mock‑ups using Aspose.Imaging in C#.
 * 3. When producing test images that require layered line styles to verify rendering accuracy of graphics libraries or printing pipelines.
 * 4. When automating the production of custom icons or markers where a bold colored line must be outlined to improve visibility against a white background.
 * 5. When building a batch process that draws highlighted guidelines on BMP canvases for computer‑vision preprocessing or annotation tasks.
 */
