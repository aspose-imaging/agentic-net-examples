// HOW-TO: Convert EPS to High Resolution PNG with Custom Size in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "input/input.eps";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = 2000,
                    PageHeight = 2000
                };

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to render a vector EPS logo at 2000×2000 pixels for web display as a PNG with transparency.
 * 2. When an automated build process must convert design assets from EPS to high‑resolution PNGs for mobile app resources.
 * 3. When a reporting tool requires rasterizing EPS charts into PNG images with truecolor and alpha for inclusion in PDFs.
 * 4. When a batch script processes user‑uploaded EPS files and saves them as PNGs with a fixed size for a content‑management system.
 * 5. When you want to ensure consistent PNG output by specifying rasterization options while converting EPS files in a C# application.
 */
