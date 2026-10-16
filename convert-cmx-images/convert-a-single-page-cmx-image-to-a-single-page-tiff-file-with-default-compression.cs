// HOW-TO: Convert a Single Page CMX to TIFF with Default Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to import legacy CorelDRAW CMX artwork into a workflow that only accepts TIFF files for printing or archival.
 * 2. When a document management system requires TIFF images, and you must programmatically convert incoming CMX files without altering image quality.
 * 3. When automating batch processing of single‑page CMX drawings to generate TIFFs for OCR engines that support only TIFF input.
 * 4. When integrating Aspose.Imaging into a C# application to replace manual conversion of CMX graphics to TIFF for web publishing.
 * 5. When a legacy CAD export provides CMX files and you need to store them as compressed TIFFs for efficient storage in a database.
 */
