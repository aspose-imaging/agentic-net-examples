// HOW-TO: Create BMP Image and Mirror Diagonal Line Using Transform in C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 200;
            int height = 200;

            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width - 1, height - 1));

                Matrix reflectMatrix = new Matrix(-1, 0, 0, 1, width - 1, 0);
                graphics.MultiplyTransform(reflectMatrix);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width - 1, height - 1));

                canvas.Save();
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
 * 1. When you need to programmatically generate a BMP file with a symmetric diagonal pattern for UI icons or logos.
 * 2. When you want to create a mirrored version of a drawn line to test reflection transformations in image processing algorithms.
 * 3. When you are building a game asset pipeline that requires automatically flipping graphics across the vertical axis.
 * 4. When you need to produce a test BMP image containing both original and reflected lines to validate Aspose.Imaging’s matrix operations.
 * 5. When you are adding a mirrored watermark or decorative line to a document image without using external editing tools.
 */
