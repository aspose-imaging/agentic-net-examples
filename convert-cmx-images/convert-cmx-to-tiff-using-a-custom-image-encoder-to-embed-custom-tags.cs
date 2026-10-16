// HOW-TO: Convert CMX File to TIFF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.cmx");
            string outputPath = Path.Combine(baseDir, "Output", "result.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image cmxImage = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX drawings to TIFF for archival or printing workflows in a .NET application.
 * 2. When integrating an automated pipeline that ingests CMX files and outputs high‑resolution TIFF images for downstream image analysis.
 * 3. When building a document management system that must store vector drawings as lossless TIFFs to ensure compatibility with third‑party viewers.
 * 4. When creating a batch conversion tool that processes multiple CMX files from a folder and saves them as TIFFs on a server.
 * 5. When a C# service must convert CMX artwork to TIFF before applying further processing such as OCR or watermarking.
 */
