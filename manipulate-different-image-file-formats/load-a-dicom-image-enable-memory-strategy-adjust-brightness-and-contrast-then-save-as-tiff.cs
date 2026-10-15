// HOW-TO: Load DICOM Image, Adjust Brightness and Contrast, Save As TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output\\output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions { BufferSizeHint = 64 * 1024 * 1024 };
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath, loadOptions))
            {
                dicom.AdjustBrightness(50);
                dicom.AdjustContrast(0.2f);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicom.Save(outputPath, tiffOptions);
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
 * 1. When a radiology software needs to convert raw DICOM scans to high‑resolution TIFF files while enhancing visibility by increasing brightness and contrast.
 * 2. When a healthcare application must process large DICOM files on limited memory by using a custom buffer size before exporting them to TIFF for archival.
 * 3. When a developer wants to integrate Aspose.Imaging to adjust image quality of medical images programmatically and store the results in a widely supported TIFF format.
 * 4. When a PACS system requires automated preprocessing of DICOM images to improve diagnostic clarity before sending them to external viewers that only support TIFF.
 * 5. When a C# batch‑processing tool needs to read DICOM files, apply consistent brightness/contrast corrections, and save the output as TIFF for further analysis or printing.
 */
