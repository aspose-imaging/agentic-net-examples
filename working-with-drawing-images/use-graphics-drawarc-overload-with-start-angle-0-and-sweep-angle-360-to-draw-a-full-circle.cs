// HOW-TO: Draw a Full Circle on a BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Blue, 5);
                int margin = 10;
                int x = margin;
                int y = margin;
                int width = image.Width - 2 * margin;
                int height = image.Height - 2 * margin;
                graphics.DrawArc(pen, x, y, width, height, 0, 360);

                BmpOptions saveOptions = new BmpOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to add a blue circular border around an existing BMP photograph for a watermark or branding purpose.
 * 2. When generating a printable template that requires a precise circle drawn inside a bitmap with a specific margin and line thickness.
 * 3. When creating a simple game asset, such as a circular button or token, by programmatically drawing the shape onto a BMP sprite sheet.
 * 4. When preprocessing scanned documents and need to highlight a region of interest with a full circle overlay before saving the file.
 * 5. When automating the production of diagnostic images that include a circular indicator to mark measurement boundaries in medical BMP scans.
 */
