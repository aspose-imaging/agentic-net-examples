// HOW-TO: Add Text Watermark to BMP Image with Opacity in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output/watermarked.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                var graphics = new Graphics(raster);

                string watermarkText = "Sample Watermark";
                int opacity = 128; // 0-255

                var font = new Font("Arial", 24);
                var textSize = graphics.MeasureString(
                    watermarkText,
                    font,
                    new SizeF(raster.Width, raster.Height),
                    new StringFormat()
                );

                int margin = 10;
                float x = raster.Width - textSize.Width - margin;
                float y = raster.Height - textSize.Height - margin;

                var brushColor = Color.FromArgb(opacity, Color.White);
                using (var brush = new SolidBrush(brushColor))
                {
                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));
                }

                var options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to protect BMP assets by overlaying a semi‑transparent copyright notice before distributing them.
 * 2. When generating product catalogs that require a discreet brand logo or text on each BMP photo without altering the original image colors.
 * 3. When creating batch‑processed screenshots for documentation and want to add a consistent identifier at the bottom‑right corner.
 * 4. When preparing BMP images for a web portal and need to embed a low‑opacity disclaimer that remains readable on any background.
 * 5. When automating the addition of legal watermarks to scanned BMP documents to comply with archival standards.
 */
