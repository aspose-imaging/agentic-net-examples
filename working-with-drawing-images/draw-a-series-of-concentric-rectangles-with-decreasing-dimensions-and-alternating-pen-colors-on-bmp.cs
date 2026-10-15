// HOW-TO: Create BMP with Concentric Colored Rectangles Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int rectCount = 10;
                int marginStep = Math.Min(width, height) / (2 * rectCount);

                for (int i = 0; i < rectCount; i++)
                {
                    int margin = i * marginStep;
                    int rectWidth = width - 2 * margin;
                    int rectHeight = height - 2 * margin;
                    Rectangle rect = new Rectangle(margin, margin, rectWidth, rectHeight);
                    Color penColor = (i % 2 == 0) ? Color.Red : Color.Blue;
                    Pen pen = new Pen(penColor, 3);
                    graphics.DrawRectangle(pen, rect);
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
 * 1. When you need to generate a patterned background image for a UI element, such as a framed button or panel, you can draw concentric rectangles on a BMP file with Aspose.Imaging.
 * 2. When testing image‑processing algorithms that detect shapes or color boundaries, this code quickly produces a BMP containing alternating red and blue rectangles.
 * 3. When producing printable graphics like a target or bullseye design for reports or posters, the concentric rectangle routine creates the required BMP image.
 * 4. When adding a decorative overlay or custom watermark to scanned documents, you can programmatically layer rectangles with different pen colors using the Aspose.Imaging drawing API.
 * 5. When benchmarking the performance of Aspose.Imaging’s Graphics and Pen classes, generating multiple concentric rectangles on a BMP provides a repeatable workload.
 */
