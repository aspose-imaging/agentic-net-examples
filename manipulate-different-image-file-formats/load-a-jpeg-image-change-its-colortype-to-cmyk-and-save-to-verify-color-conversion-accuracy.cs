// HOW-TO: Convert JPEG to CMYK Color Space and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample_cmyk.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions();
                options.ColorType = JpegCompressionColorMode.Cmyk;
                image.Save(outputPath, options);
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
 * 1. When preparing print‑ready artwork, you need to convert RGB JPEGs to CMYK to match the press color profile.
 * 2. When integrating a web service that receives JPEGs and must store them in CMYK for downstream publishing pipelines.
 * 3. When validating color conversion accuracy by saving a JPEG with the CMYK color mode and comparing it to the original.
 * 4. When migrating a legacy image library to Aspose.Imaging and need to ensure JPEGs are saved in CMYK for compliance with branding guidelines.
 * 5. When building a batch processing tool that converts user‑uploaded JPEG photos to CMYK before archiving them in a digital asset management system.
 */
