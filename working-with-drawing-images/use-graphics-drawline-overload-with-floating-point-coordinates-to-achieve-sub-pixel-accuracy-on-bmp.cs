// HOW-TO: Draw Subpixel Line on BMP Using Aspose.Imaging Graphics in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 1);
                graphics.DrawLine(pen, 10.5f, 10.5f, 150.75f, 150.25f);

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
 * 1. When you need to generate a BMP diagram with precisely positioned lines for technical schematics, using floating‑point coordinates to avoid jagged edges.
 * 2. When creating custom UI assets such as icons or overlays where sub‑pixel line rendering improves visual sharpness on high‑resolution displays.
 * 3. When programmatically adding measurement markers to engineering drawings saved as BMP files, requiring exact placement beyond whole‑pixel limits.
 * 4. When producing pixel‑perfect graphics for printing where BMP output must retain fine line detail with anti‑aliasing control via Aspose.Imaging.
 * 5. When automating the generation of map routes or graph edges in BMP format and need sub‑pixel accuracy to align lines with geographic coordinates.
 */
