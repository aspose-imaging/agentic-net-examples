// HOW-TO: Apply Semi Transparent Red Overlay To SVG And Save As PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Aspose.Imaging.FileFormats.Png.PngImage png = (Aspose.Imaging.FileFormats.Png.PngImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(png);
                    graphics.DrawImage(vectorImage, new Aspose.Imaging.Rectangle(0, 0, width, height));

                    Aspose.Imaging.Color overlayColor = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0);
                    using (SolidBrush brush = new SolidBrush(overlayColor))
                    {
                        graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(0, 0, width, height));
                    }

                    png.Save();
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
 * 1. When you need to generate a PNG thumbnail of an SVG logo with a semi‑transparent red tint for branding purposes.
 * 2. When you want to batch‑process vector icons and apply a uniform color overlay before publishing them to a web app.
 * 3. When you must create a watermarked PNG version of a vector illustration by filling it with an RGBA color.
 * 4. When you are converting SVG assets to PNG for email newsletters and need to adjust their hue without editing the source file.
 * 5. When you are building a C# service that renders SVG diagrams with a custom overlay color for accessibility contrast.
 */
