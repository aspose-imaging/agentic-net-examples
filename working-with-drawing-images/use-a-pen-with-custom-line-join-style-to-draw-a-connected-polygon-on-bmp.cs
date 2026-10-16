// HOW-TO: Draw a Connected Polygon with Miter Line Join on BMP Using C# (Aspose.Imaging for .NET)
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
        string outputPath = "output/output.bmp";

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

                Pen pen = new Pen(Color.Blue, 5);
                pen.LineJoin = LineJoin.Miter;

                Point[] points = new Point[]
                {
                    new Point(50, 50),
                    new Point(350, 50),
                    new Point(350, 250),
                    new Point(50, 250)
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
 * 1. When you need to generate a BMP image that outlines a rectangular area with sharp corners using Aspose.Imaging in C#.
 * 2. When creating a custom map overlay where the border must be drawn with a specific line join style (Miter) for visual consistency.
 * 3. When producing a thumbnail with a solid blue polygon of a defined thickness directly into a BMP file.
 * 4. When automating printable forms that include bordered sections drawn programmatically as polygons in BMP format.
 * 5. When developing a game asset pipeline that draws level boundaries with precise miter joins for collision‑visualization purposes.
 */
