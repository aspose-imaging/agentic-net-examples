// HOW-TO: Create A 10x10 Grid BMP Image With DrawLine In C# (Aspose.Imaging for .NET)
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
            // Define output path
            string outputPath = "output/grid.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Grid parameters
            int rows = 10;
            int cols = 10;
            int cellSize = 50;
            int width = cols * cellSize;
            int height = rows * cellSize;

            // Create BMP options with file source
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Create pen
                Pen pen = new Pen(Color.Black, 1);

                // Create graphics object
                Graphics graphics = new Graphics(image);

                // Draw horizontal lines
                for (int i = 0; i <= rows; i++)
                {
                    int y = i * cellSize;
                    graphics.DrawLine(pen, 0, y, width, y);
                }

                // Draw vertical lines
                for (int j = 0; j <= cols; j++)
                {
                    int x = j * cellSize;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (output file already bound)
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
 * 1. When you need to generate a printable graph‑paper background as a BMP file for a desktop application.
 * 2. When you want to create a tiled game board image with equal cells for a C# game engine.
 * 3. When you must produce a layout template for OCR training data by drawing a uniform grid on a bitmap.
 * 4. When you require a simple way to overlay a coordinate grid on a scanned image before further processing.
 * 5. When you need to programmatically generate a spreadsheet‑style grid image for reports or documentation using Aspose.Imaging.
 */
