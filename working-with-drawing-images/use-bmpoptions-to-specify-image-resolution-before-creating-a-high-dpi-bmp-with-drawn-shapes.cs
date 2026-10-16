// HOW-TO: Create High DPI BMP with Shapes Using BmpOptions in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output\\highdpi.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                int width = 800;
                int height = 600;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    if (image is RasterImage rasterImg)
                    {
                        rasterImg.HorizontalResolution = 300;
                        rasterImg.VerticalResolution = 300;
                    }

                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen redPen = new Pen(Color.Red, 5);
                    graphics.DrawRectangle(redPen, 50, 50, 200, 150);

                    Pen bluePen = new Pen(Color.Blue, 3);
                    graphics.DrawLine(bluePen, 300, 300, 500, 400);

                    Pen greenPen = new Pen(Color.Green, 4);
                    graphics.DrawEllipse(greenPen, 400, 100, 150, 100);

                    image.Save();
                }
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
 * 1. When you need to generate a 300 dpi BMP for high‑quality printing with custom graphics drawn programmatically in C#.
 * 2. When you must create a bitmap file with specific bits‑per‑pixel and resolution settings before adding vector shapes for a desktop application.
 * 3. When an automated report generator requires a high‑resolution BMP thumbnail that includes rectangles, lines, and ellipses.
 * 4. When a CAD or GIS tool needs to export a raster image at a defined DPI to maintain scale accuracy for engineering drawings.
 * 5. When a web service creates printable BMP assets on the fly and must control both image size and DPI to meet publishing standards.
 */
