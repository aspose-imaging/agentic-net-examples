// HOW-TO: Export Second Page of Multipage TIFF to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output\\second_page.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiff = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                options.MultiPageOptions = new MultiPageOptions(new IntRange(2, 2));
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
 * 1. When you need to extract a single page from a multi‑page scanned document (TIFF) and save it as a lightweight PNG for web preview in a C# application.
 * 2. When generating thumbnails for specific pages of a multi‑page TIFF archive, such as the second page of a fax, using Aspose.Imaging’s MultiPageOptions.
 * 3. When automating a workflow that converts only the relevant page of a multi‑page medical image (TIFF) to PNG for inclusion in a patient report.
 * 4. When creating a batch process that isolates and exports a particular page from large TIFF files to PNG to reduce storage size and improve loading speed.
 * 5. When integrating image processing into a .NET service that must deliver only the second page of a multi‑page TIFF as a PNG to downstream systems or APIs.
 */
