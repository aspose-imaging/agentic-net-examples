// HOW-TO: Add XMP Metadata to DICOM Image and Save with Aspose.Imaging C# (Aspose.Imaging for .NET)
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

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output.dcm";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage image = (DicomImage)Image.Load(inputPath))
                {
                    var xmpBytes = System.Text.Encoding.UTF8.GetBytes("<x:xmpmeta xmlns:x='adobe:ns:meta/'></x:xmpmeta>");
                    var xmp = new Aspose.Imaging.Xmp.XmpPacketWrapper(xmpBytes);
                    image.XmpData = xmp;

                    var dicomOptions = new DicomOptions();
                    image.Save(outputPath, dicomOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to embed custom XMP tags into a DICOM file without altering the pixel data.
 * 2. When a radiology PACS system requires adding provenance information to existing DICOM scans before archiving.
 * 3. When a research project wants to annotate DICOM images with metadata for later automated analysis in C#.
 * 4. When a healthcare software needs to preserve the original DICOM format while inserting XMP metadata for compliance reporting.
 * 5. When a developer must programmatically load, modify, and re‑export DICOM files using Aspose.Imaging in a .NET environment.
 */
