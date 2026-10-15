// HOW-TO: Extract Specific Region from DjVu and Save as TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(0, new Aspose.Imaging.Rectangle(100, 100, 200, 200));
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate a high‑resolution TIFF thumbnail of a selected area from a DjVu document for archival or printing purposes.
 * 2. When a web service must extract a portion of a scanned DjVu file to create a preview image for a document management system.
 * 3. When converting a specific region of a DjVu map or blueprint into TIFF format for further analysis in GIS or CAD tools.
 * 4. When automating batch processing to isolate and save particular sections of DjVu manuals as TIFF files for offline viewing on devices that only support TIFF.
 * 5. When integrating Aspose.Imaging into a C# application to extract a defined rectangle from a DjVu file and store it as a TIFF image for compliance reporting.
 */
