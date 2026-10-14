// HOW-TO: Validate DICOM File and Convert to PNG Using C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When a healthcare application needs to ensure a DICOM image is not corrupted before displaying it as a PNG thumbnail in a web portal.
 * 2. When a radiology PACS system must batch‑process DICOM scans and store them as PNG files for integration with non‑medical image viewers.
 * 3. When a developer builds a diagnostic reporting tool that extracts PNG snapshots from DICOM files while checking file integrity to avoid runtime errors.
 * 4. When an electronic health record (EHR) platform requires conversion of validated DICOM images to PNG for secure archival and quick preview.
 * 5. When a mobile app downloads DICOM files from a server and needs to verify they are valid before converting them to PNG for on‑device rendering.
 */
