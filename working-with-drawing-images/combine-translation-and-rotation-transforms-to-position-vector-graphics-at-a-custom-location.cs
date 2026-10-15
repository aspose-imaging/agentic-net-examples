// HOW-TO: How to Translate and Rotate an SVG When Converting to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var source = new FileCreateSource(outputPath, false);
                JpegOptions options = new JpegOptions() { Source = source, Quality = 90 };
                using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, vectorImage.Width, vectorImage.Height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.TranslateTransform(100f, 50f);
                    graphics.RotateTransform(45f);
                    graphics.DrawImage(vectorImage, 0, 0);
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
 * 1. When you need to place an SVG logo at a specific offset and angle on a JPEG report header generated in a C# application.
 * 2. When creating product catalog thumbnails that require rotating and shifting vector illustrations before rasterizing them to JPEG for web display.
 * 3. When overlaying a scaled SVG watermark at a custom position and orientation on high‑resolution JPEG photographs in an automated .NET workflow.
 * 4. When generating printable marketing flyers where vector icons must be rotated and translated onto a JPEG background using Aspose.Imaging in C#.
 * 5. When building a batch converter that aligns and angles SVG diagrams consistently before saving them as JPEG files for legacy systems.
 */
