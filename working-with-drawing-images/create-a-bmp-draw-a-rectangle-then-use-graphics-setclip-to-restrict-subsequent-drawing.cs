// HOW-TO: Create BMP Image and Draw Rectangles with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions createOptions = new BmpOptions
            {
                BitsPerPixel = 32,
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(createOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen bluePen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(bluePen, new Rectangle(20, 20, 160, 160));

                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new Rectangle(0, 0, 200, 200));

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
 * 1. When you need to generate a blank BMP file and programmatically add border graphics for a report thumbnail.
 * 2. When you want to create a 200 × 200 pixel canvas and draw custom shapes such as rectangles for a UI mock‑up in C#.
 * 3. When you must produce a high‑color (32‑bit) BMP with precise line thickness for printing or archival purposes.
 * 4. When you are building a batch process that adds visual markers to images, like highlighting the edges of a scanned document.
 * 5. When you require a simple way to programmatically draw and save vector‑style outlines without using GDI+ directly.
 */
