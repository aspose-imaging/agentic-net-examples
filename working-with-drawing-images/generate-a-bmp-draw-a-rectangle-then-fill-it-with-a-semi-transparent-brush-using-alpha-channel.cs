// HOW-TO: Create BMP with Semi Transparent Filled Rectangle in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            int width = 300;
            int height = 250;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Rectangle rect = new Rectangle(50, 50, 200, 150);

                using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(fillBrush, rect);
                }

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

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
 * 1. When you need to generate a BMP report thumbnail that highlights a region with a translucent overlay for visual emphasis.
 * 2. When creating a custom watermark on a BMP image by drawing a semi‑transparent rectangle over the content.
 * 3. When building a UI component that programmatically produces BMP assets with highlighted selection boxes using alpha‑blended colors.
 * 4. When exporting diagram layers to BMP where a specific area must be shaded with a 50 % opaque fill to indicate status.
 * 5. When automating batch image processing that adds a semi‑transparent colored border to BMP files for branding or UI guidelines.
 */
