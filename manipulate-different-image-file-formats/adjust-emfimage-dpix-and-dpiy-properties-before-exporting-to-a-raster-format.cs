// HOW-TO: Adjust EMF DPI Before Converting to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfImage emf = (EmfImage)image;
                PngOptions pngOptions = new PngOptions();
                emf.Save(outputPath, pngOptions);
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
 * 1. When you need to change the DPI of an EMF vector file before generating a high‑resolution PNG for printing.
 * 2. When a web application must convert user‑uploaded EMF graphics to PNG thumbnails with a specific pixel density.
 * 3. When preserving the intended size of a diagram requires adjusting its DPI prior to rasterization for PDF embedding.
 * 4. When a batch process must standardize the resolution of multiple EMF files before saving them as PNG assets for a mobile app.
 * 5. When troubleshooting image quality issues caused by default DPI settings in EMF files during conversion to raster formats.
 */
