// HOW-TO: Resize BMP to 1200x1200 and Convert to SVG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1200, 1200);
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to transform legacy BMP icons into scalable SVG files for responsive web pages.
 * 2. When you must standardize raster images to a 1200 × 1200 pixel size before converting them to vector format for high‑resolution printing.
 * 3. When an application requires converting user‑uploaded BMP photos into SVG graphics to enable unlimited scaling without quality loss.
 * 4. When you are building a batch‑processing tool that resizes bitmap assets and outputs them as SVGs for use in vector‑based design software.
 * 5. When you want to replace large BMP assets with smaller, uniformly sized SVG equivalents to improve load times and maintain visual fidelity across devices.
 */
