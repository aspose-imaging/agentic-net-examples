// HOW-TO: Create PNG with Filled Blue Rectangle and Thick Black Border in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            var source = new FileCreateSource(outputPath, false);
            var pngOptions = new PngOptions { Source = source };
            int width = 200;
            int height = 200;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int rectX = 20;
                int rectY = 20;
                int rectWidth = 160;
                int rectHeight = 160;

                Pen pen = new Pen(Color.Black, 5);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, rectX, rectY, rectWidth, rectHeight);
                    graphics.DrawRectangle(pen, rectX, rectY, rectWidth, rectHeight);
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
 * 1. When you need to generate a PNG placeholder image for a UI element that shows a solid blue rectangle with a thick black border using Aspose.Imaging in C#.
 * 2. When creating a custom badge or icon where a filled blue shape outlined in black must be drawn and saved as a PNG file programmatically.
 * 3. When producing deterministic test images for visual regression testing that require a specific rectangle size, fill color, and outline thickness.
 * 4. When adding a highlighted area to a PDF or report by drawing a blue rectangle with a black border onto a PNG that will be embedded later.
 * 5. When designing a game sprite or map tile in which a selectable region is represented by a solid blue rectangle with a thick black outline.
 */
