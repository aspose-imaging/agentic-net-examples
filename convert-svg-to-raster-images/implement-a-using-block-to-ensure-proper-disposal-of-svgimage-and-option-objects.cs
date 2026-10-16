// HOW-TO: Convert SVG to PNG with Aspose.Imaging Using Block in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            using (PngOptions pngOptions = new PngOptions())
            {
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from user‑uploaded SVG graphics in a .NET web application.
 * 2. When a desktop utility must batch‑convert a folder of SVG icons to PNG for inclusion in a Windows UI.
 * 3. When an automated build script creates PNG assets from SVG design files for mobile app resources.
 * 4. When a reporting service renders vector charts stored as SVG into raster PNG images for PDF export.
 * 5. When a cloud function processes SVG logos and saves them as PNG files while ensuring memory is released promptly.
 */
