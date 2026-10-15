// HOW-TO: Convert WMF to 24‑Bit BMP in C# With Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace ImageConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.wmf";
                string outputPath = "output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display legacy WMF vector graphics in a Windows application that only supports raster BMP files with full 24‑bit color.
 * 2. When exporting diagrams from older CAD tools as WMF and converting them to high‑color BMP for printing or archival purposes.
 * 3. When a batch process must transform WMF icons into BMP thumbnails for use in file explorers or image galleries.
 * 4. When integrating with a third‑party system that requires BMP input and cannot handle WMF, ensuring color fidelity by using 24‑bit depth.
 * 5. When preparing WMF assets for a game engine that loads BMP textures, needing a straightforward C# conversion with Aspose.Imaging.
 */
