// HOW-TO: Convert EPS to Grayscale PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Grayscale
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a lightweight grayscale preview of a vector EPS logo for a web page using Aspose.Imaging in C#.
 * 2. When converting print‑ready EPS artwork to PNG for inclusion in a PDF report that requires grayscale images via Aspose.Imaging.
 * 3. When preparing EPS diagrams for a mobile app that only supports PNG and prefers reduced color depth to save memory, using C# code.
 * 4. When automating a batch process that transforms EPS files into grayscale PNGs for archival in a document management system with Aspose.Imaging.
 * 5. When creating grayscale thumbnails from EPS files for an e‑commerce catalog that displays product images in PNG format using Aspose.Imaging.
 */
