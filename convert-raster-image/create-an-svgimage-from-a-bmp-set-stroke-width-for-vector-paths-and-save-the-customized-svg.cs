// HOW-TO: Convert BMP Image to Scalable SVG with Custom Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\custom.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image bmp = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = bmp.Width,
                        PageHeight = bmp.Height
                    }
                };

                bmp.Save(outputPath, options);
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
 * 1. When you need to embed a legacy BMP graphic into a web page as a resolution‑independent SVG without losing its original dimensions.
 * 2. When an automated pipeline must transform scanned bitmap assets into vector‑friendly SVG files for further editing in design tools.
 * 3. When you want to generate white‑background SVG placeholders from BMP icons for responsive UI layouts in a C# application.
 * 4. When a reporting system requires converting bitmap charts into scalable SVGs to ensure crisp printing at any size.
 * 5. When a batch process has to create SVG versions of BMP files while preserving their width and height for consistent layout rendering.
 */
