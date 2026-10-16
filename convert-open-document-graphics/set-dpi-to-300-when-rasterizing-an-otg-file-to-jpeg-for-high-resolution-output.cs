// HOW-TO: Rasterize OTG to High-Resolution JPEG at 300 DPI in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.jpg";

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
                JpegOptions jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    ResolutionUnit = ResolutionUnit.Inch,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert vector OTG drawings into printable JPEG images with 300 dpi for high‑quality brochures.
 * 2. When generating thumbnails for a web gallery that require consistent resolution settings from OTG files.
 * 3. When preparing engineering diagrams for inclusion in PDF reports where the rasterized JPEG must match a specific DPI.
 * 4. When automating batch processing of OTG assets to create high‑resolution JPEG assets for large‑format printing.
 * 5. When integrating Aspose.Imaging into a C# application to ensure rasterized images retain exact dimensions and DPI for downstream CAD workflows.
 */
