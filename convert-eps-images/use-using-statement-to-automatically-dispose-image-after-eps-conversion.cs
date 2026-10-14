// HOW-TO: Convert EPS to Grayscale PNG and SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace EPSConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.eps";
                string pngOutputPath = "output/output.png";
                string svgOutputPath = "output/output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                using (var image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale
                    };
                    image.Save(pngOutputPath, pngOptions);

                    var svgOptions = new SvgOptions();
                    image.Save(svgOutputPath, svgOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready grayscale PNG thumbnails from EPS artwork for a product catalog.
 * 2. When you must provide both raster (PNG) and vector (SVG) versions of a logo originally supplied as EPS for responsive design.
 * 3. When an automated build pipeline processes incoming EPS files and outputs optimized image formats for downstream publishing.
 * 4. When a desktop application allows users to import EPS drawings and export them as SVG for editing in vector editors.
 * 5. When you want to ensure proper resource cleanup by loading an EPS file in a using block before saving it to multiple formats.
 */
