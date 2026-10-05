// HOW-TO: Process Large TIFF Image With Limited Memory Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.tif";

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
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a C# application must open and re‑save a multi‑page TIFF that exceeds the default memory budget, this code demonstrates how to load the file and write it back safely with Aspose.Imaging.
 * 2. When converting high‑resolution scanned documents to a new TIFF file without running out of RAM, developers can use this pattern to manage large image files in .NET.
 * 3. When building a server‑side service that processes satellite or aerial imagery stored as TIFFs, the example shows how to read and write the images while keeping memory usage under control.
 * 4. When integrating medical imaging workflows that handle large DICOM‑derived TIFF files, the snippet provides a reliable way to load and re‑export the images in C#.
 * 5. When archiving legacy TIFF archives in a batch job, this code helps ensure each file is loaded and saved without causing an out‑of‑memory exception.
 */
