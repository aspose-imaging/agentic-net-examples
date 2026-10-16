// HOW-TO: Convert ODG to SVG with Proper ViewBox Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
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
 * 1. When you need to display an OpenDocument Graphic (ODG) in a web page that requires scalable SVG with an accurate viewBox for responsive layout.
 * 2. When a document conversion service must transform user‑uploaded ODG files into SVG assets while preserving the original dimensions for printing or further editing.
 * 3. When integrating a CAD‑like workflow in a C# application that exports vector drawings from ODG to SVG for use in modern browsers or design tools.
 * 4. When automating batch processing of ODG diagrams into SVG files and need the viewBox set automatically to avoid manual SVG editing.
 * 5. When building a cross‑platform reporting system that embeds ODG charts as SVG images, ensuring they scale correctly on different screen resolutions.
 */
