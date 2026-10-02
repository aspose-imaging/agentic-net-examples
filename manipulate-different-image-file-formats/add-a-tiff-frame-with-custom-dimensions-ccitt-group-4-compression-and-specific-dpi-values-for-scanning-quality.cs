// HOW-TO: Add Custom Sized CCITT Group 4 TIFF Frame With 300 DPI In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output\\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.CcittFax4;

                int frameWidth = 800;
                int frameHeight = 600;

                using (TiffFrame newFrame = new TiffFrame(frameOptions, frameWidth, frameHeight))
                {
                    newFrame.HorizontalResolution = 300;
                    newFrame.VerticalResolution = 300;
                    tiffImage.AddFrame(newFrame);
                }

                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to create a high‑resolution, fax‑compatible TIFF page for archival scanning systems.
 * 2. When adding a new page to an existing multi‑page TIFF document with specific width, height, and 300 DPI resolution for printing.
 * 3. When generating a compressed TIFF frame using CCITT Group 4 to reduce file size while preserving black‑and‑white scan quality.
 * 4. When integrating scanned documents into a workflow that requires each page to have exact dimensions and DPI metadata for downstream OCR processing.
 * 5. When building a document management solution that must append additional TIFF frames with uniform compression and resolution settings to maintain consistency across all pages.
 */
