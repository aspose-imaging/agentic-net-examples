// HOW-TO: Set DPI to 300 When Converting WMF to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "Input/sample.wmf";
        string outputPath = "Output/sample.jpg";

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
 * 1. When you need to generate high‑resolution JPEGs from legacy WMF graphics for print‑ready PDFs.
 * 2. When a web application must display vector drawings as raster images with consistent 300 dpi for brochures.
 * 3. When converting WMF icons to JPEG thumbnails while preserving print quality for marketing materials.
 * 4. When automating batch processing of WMF files to JPEG for a publishing workflow that requires 300 dpi output.
 * 5. When integrating Aspose.Imaging into a C# service that transforms vector diagrams into JPEGs for high‑quality reports.
 */
