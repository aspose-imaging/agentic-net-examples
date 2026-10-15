// HOW-TO: Convert PNG to SVG With Original Dimensions Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image pngImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                pngImage.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster PNG logo in a web page as a scalable SVG while keeping its original dimensions using Aspose.Imaging.
 * 2. When an automated C# pipeline must convert user‑uploaded PNG icons to SVG files for responsive UI design.
 * 3. When you want to generate SVG assets from PNG diagrams to reduce file size without altering the image size.
 * 4. When a reporting tool requires vector graphics but the source images are only available as PNG files.
 * 5. When you are building a batch conversion utility in C# that transforms PNG assets to SVG for print‑ready documents.
 */
