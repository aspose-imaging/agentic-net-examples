// HOW-TO: Convert EMF to PNG with Anti-Aliasing in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                vectorOptions.BackgroundColor = Aspose.Imaging.Color.White;
                vectorOptions.PageWidth = image.Width;
                vectorOptions.PageHeight = image.Height;
                vectorOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;
                vectorOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias;
                pngOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When you need to display vector‑based EMF diagrams on the web as high‑quality PNG images with smooth edges.
 * 2. When generating thumbnails of EMF charts for reports and you want anti‑aliased rendering to avoid jagged lines.
 * 3. When converting legacy Windows Metafile graphics to PNG for cross‑platform mobile apps while preserving text clarity.
 * 4. When automating batch processing of EMF logos to PNG for branding assets and require a consistent white background and anti‑aliasing.
 * 5. When integrating Aspose.Imaging in a C# service that transforms EMF files into PNGs for PDF generation with improved visual fidelity.
 */
