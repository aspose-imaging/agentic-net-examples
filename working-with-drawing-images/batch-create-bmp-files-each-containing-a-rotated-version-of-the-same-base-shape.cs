// HOW-TO: Generate Multiple Rotated BMP Images From a Base Shape in C# (Aspose.Imaging for .NET)
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
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            int width = 200;
            int height = 200;
            int[] angles = new int[] { 0, 90, 180, 270 };

            foreach (int angle in angles)
            {
                string outputPath = Path.Combine(outputDir, $"rotated_{angle}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions options = new BmpOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Black, 2);
                    Rectangle rect = new Rectangle(50, 50, 100, 100);
                    graphics.DrawRectangle(pen, rect);

                    canvas.Rotate(angle, true, Color.White);
                    canvas.Save();
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
 * 1. When you need to create a set of BMP icons showing a logo at 0°, 90°, 180°, and 270° for a UI that supports screen rotation.
 * 2. When generating test images for automated visual regression testing that require the same shape rotated at different angles.
 * 3. When preparing assets for a game that uses BMP sprites rotated to match character orientation without using external image editors.
 * 4. When producing printable templates where a diagram must be supplied in all four cardinal orientations as separate BMP files.
 * 5. When building a batch processing tool that programmatically adds a rotated watermark rectangle to multiple BMP files for compliance documentation.
 */
