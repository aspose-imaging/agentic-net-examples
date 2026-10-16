// HOW-TO: Load Multi-Page TIFF and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, options);
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
 * 1. When you need to open a scanned multi-page TIFF document in a C# application, modify its metadata, and write it back to disk using Aspose.Imaging.
 * 2. When a workflow requires converting a multi-frame TIFF from one compression type to another while preserving all pages in .NET.
 * 3. When you want to validate that a TIFF file exists, load it, and re-save it to a new location to ensure it conforms to Aspose’s default TIFF format.
 * 4. When integrating a document management system that must read multi-page TIFFs and store them unchanged after processing in a C# service.
 * 5. When a medical imaging application needs to load a multi-page DICOM-derived TIFF, apply server-side handling, and save the file using Aspose.Imaging for further analysis.
 */
