// HOW-TO: Create BMP With Ivory Background And Diagonal Hatch Pattern In C# (Aspose.Imaging for .NET)
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
            int width = 500;
            int height = 500;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Ivory);

                Pen pen = new Pen(Color.Black);
                int step = 20;

                // Diagonal lines from top-left to bottom-right
                for (int i = -width; i < width; i += step)
                {
                    graphics.DrawLine(pen, i, 0, i + height, height);
                }

                // Diagonal lines from top-right to bottom-left
                for (int i = 0; i < width + height; i += step)
                {
                    graphics.DrawLine(pen, i, 0, i - height, height);
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
 * 1. When you need to generate a plain BMP file as a neutral ivory placeholder image for UI mockups or testing.
 * 2. When you want to add a diagonal hatch texture to a bitmap programmatically for background shading in games or diagrams.
 * 3. When you must create a printable pattern of intersecting diagonal lines for engineering drawings or technical reports using C#.
 * 4. When you need a BMP with a repeatable hatch pattern to serve as a tiled overlay in GIS or mapping applications.
 * 5. When you are building a simple watermark or security pattern directly onto an image without using external graphics software.
 */
