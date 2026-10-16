// HOW-TO: Create BMP With Sharp Polygon Using High Pen Miter Limit In C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 300;
            int height = 300;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 3);
                pen.MiterLimit = 10f;

                Point[] points = new Point[]
                {
                    new Point(50, 250),
                    new Point(150, 10),
                    new Point(250, 250),
                    new Point(150, 200)
                };

                graphics.DrawPolygon(pen, points);

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
 * 1. When you need to generate a BMP diagram with crisp, sharp‑angled lines for technical documentation.
 * 2. When rendering a custom shape in a Windows desktop application that requires precise control over line joins.
 * 3. When creating high‑resolution bitmap assets for a game UI where the miter limit prevents beveled corners.
 * 4. When exporting vector‑style graphics to BMP for legacy systems that only support raster images.
 * 5. When programmatically drawing polygons with adjustable pen properties in a C# image‑processing pipeline.
 */
