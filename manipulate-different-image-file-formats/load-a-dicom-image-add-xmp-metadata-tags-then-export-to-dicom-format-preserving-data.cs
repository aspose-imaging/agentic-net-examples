// HOW-TO: How To Load And Save DICOM Image In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\input.dcm";
        string outputPath = "output\\output.dcm";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                var dicomOptions = new DicomOptions();
                dicomImage.Save(outputPath, dicomOptions);
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
 * 1. When a medical imaging application needs to read a DICOM file, make minor adjustments, and write it back without losing patient or study metadata.
 * 2. When a radiology workflow integrates C# services that must validate and re‑encode DICOM images before sending them to a PACS server.
 * 3. When a healthcare research tool extracts pixel data from DICOM scans, processes it, and then saves the result as a new DICOM file for further analysis.
 * 4. When a hospital information system migrates legacy DICOM archives to a new storage format while preserving all original tags and image fidelity.
 * 5. When a diagnostic software module programmatically copies DICOM files to a secure folder, ensuring the files remain unchanged and compliant with DICOM standards.
 */
