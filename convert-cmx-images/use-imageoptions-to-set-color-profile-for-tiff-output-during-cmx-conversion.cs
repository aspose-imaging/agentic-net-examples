// HOW-TO: Convert CMX File to TIFF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a CAD application exports drawings as CMX and the workflow requires high‑resolution TIFF files for archival or printing, developers can use this code to perform the conversion automatically.
 * 2. When a document management system needs to index vector graphics stored in CMX by generating raster TIFF thumbnails, the snippet provides a quick way to create those images in C#.
 * 3. When integrating legacy engineering data into a modern GIS platform that only accepts TIFF rasters, developers can convert the CMX drawings on the server side using Aspose.Imaging.
 * 4. When a batch‑processing service must transform a folder of CMX files into TIFF format for compliance reporting, this code can be incorporated into a scheduled C# job.
 * 5. When a web API receives CMX uploads and must return a TIFF preview to browsers, the example shows how to load the CMX and save it as TIFF in memory or to disk.
 */
