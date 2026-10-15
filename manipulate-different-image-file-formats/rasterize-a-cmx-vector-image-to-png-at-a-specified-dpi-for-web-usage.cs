// HOW-TO: Rasterize CMX Vector Image to PNG for Web in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height
                    }
                };

                cmx.Save(outputPath, options);
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
 * 1. When you need to display legacy CMX drawings on a website that only supports raster formats like PNG.
 * 2. When you must convert a CMX vector file to a high‑resolution PNG thumbnail for product catalogs.
 * 3. When an e‑commerce platform requires white‑background PNG images generated from CMX artwork for consistent branding.
 * 4. When automating a batch process that transforms multiple CMX files into web‑ready PNGs with fixed dimensions.
 * 5. When integrating Aspose.Imaging into a C# service that serves PNG previews of CMX diagrams on demand.
 */
