// HOW-TO: Fast SVG to BMP Conversion with Low Quality Rasterization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.svg");
            string outputPath = Path.Combine("Output", "output.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new BmpOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };
                options.VectorRasterizationOptions = rasterOptions;
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
 * 1. When you need to quickly generate thumbnail BMP images from SVG icons for a web dashboard.
 * 2. When processing large batches of SVG graphics on a server and want to reduce CPU load by lowering rasterization quality.
 * 3. When converting SVG diagrams to BMP format for legacy applications that only support bitmap images, and speed is more important than visual fidelity.
 * 4. When creating low‑resolution previews of vector artwork for email attachments where file size and conversion time must be minimized.
 * 5. When automating image pipelines that export SVG assets to BMP for printing proofs and you prefer faster conversion at the expense of fine detail.
 */
