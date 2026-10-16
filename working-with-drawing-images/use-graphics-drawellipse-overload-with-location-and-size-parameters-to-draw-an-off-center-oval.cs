// HOW-TO: Draw an Off‑Center Oval on a BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Create(options, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawEllipse(pen, 100, 50, 200, 100);

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
 * 1. When you need to programmatically generate a BMP diagram that highlights a specific region with an off‑center oval using Aspose.Imaging in C#.
 * 2. When creating custom graphics for a Windows desktop application that requires drawing shapes with precise coordinates on a bitmap canvas via the Graphics.DrawEllipse overload.
 * 3. When exporting annotated screenshots to BMP format for legacy systems that only accept uncompressed bitmap files, and you need to draw an ellipse to mark areas.
 * 4. When automating the production of printable assets where a blue oval must be placed at a specific offset to align with pre‑cut templates in a BMP file.
 * 5. When building a server‑side image service that draws dynamic shapes, such as an off‑center ellipse, onto BMP images for on‑the‑fly charting.
 */
