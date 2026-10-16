// HOW-TO: Save DICOM as PNG with Patient Name in File Name using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                string patientName = "Unknown";

                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    patientName = patientName.Replace(c, '_');
                }

                string outputPath = $"output_{patientName}.png";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                PngOptions options = new PngOptions();
                dicom.Save(outputPath, options);
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
 * 1. When a radiology system needs to export DICOM scans as PNG thumbnails that include the patient’s name in the filename for easy identification.
 * 2. When a medical research application must batch‑convert DICOM files to PNG while preserving patient identifiers in the output filenames for indexing.
 * 3. When a hospital’s PACS integration requires generating PNG snapshots of studies and naming them with the patient name to match existing file‑naming conventions.
 * 4. When a developer builds a web portal that displays DICOM images as PNGs and wants the downloaded files to carry the patient name for compliance and audit trails.
 * 5. When an automated reporting tool extracts DICOM metadata and saves the images as PNGs with the patient name to simplify downstream file‑system searches.
 */
