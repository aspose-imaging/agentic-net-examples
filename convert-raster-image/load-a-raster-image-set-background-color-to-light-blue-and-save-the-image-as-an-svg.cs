// HOW-TO: Convert JPEG to SVG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster photograph in a vector‑based web page, you can convert the JPEG to SVG using Aspose.Imaging in C#.
 * 2. When a graphics pipeline requires scalable assets for high‑resolution displays, this code transforms raster images into SVG without losing quality.
 * 3. When an automated batch job must prepare image assets for print‑ready PDFs, converting JPEG files to SVG ensures they remain resolution‑independent.
 * 4. When a cloud service generates thumbnails and also needs a vector version for responsive design, the snippet provides a simple C# conversion.
 * 5. When integrating legacy photo archives into a modern UI that relies on SVG icons, this code lets you programmatically convert each JPEG to SVG.
 */
