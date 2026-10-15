// HOW-TO: Convert ODG to PNG with Custom Resolution Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
        string inputPath = "Input\\sample.odg";
        string outputPath = "Output\\sample.png";

        try
        {
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
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    },
                    ResolutionSettings = new ResolutionSetting(300, 300)
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
 * 1. When you need to generate high‑resolution PNG thumbnails from OpenDocument graphics (ODG) files for web previews.
 * 2. When an application must batch‑convert ODG drawings to PNG while preserving a white background for consistent display.
 * 3. When exporting vector ODG diagrams to raster PNG images at 300 dpi for printing or PDF embedding.
 * 4. When integrating Aspose.Imaging into a C# service that receives ODG uploads and returns PNG files with specific page dimensions.
 * 5. When automating the creation of PNG assets from ODG source files with controlled resolution for UI assets or documentation.
 */
