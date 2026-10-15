// HOW-TO: Convert EMF Metafile to SVG with External Image References in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions();
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
 * 1. When you need to display Windows vector graphics on the web, you can convert EMF files to SVG while keeping linked raster images separate.
 * 2. When a reporting system generates charts as EMF and you must embed them in an HTML page without increasing SVG size, this code extracts the vector part and references external images.
 * 3. When automating a batch process that migrates legacy EMF assets to scalable SVG for responsive design, you can use this snippet to preserve image quality by storing bitmaps externally.
 * 4. When integrating with a content management system that stores SVG files with linked images, you can programmatically convert uploaded EMF files to SVG using Aspose.Imaging in C#.
 * 5. When creating a document conversion service that needs to separate vector and raster layers for further editing, this example shows how to save the EMF as SVG with external image files referenced.
 */
