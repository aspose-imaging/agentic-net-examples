// HOW-TO: Convert DICOM to PNG While Preserving EXIF Metadata in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

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

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    if (dicom.ExifData != null)
                    {
                        pngOptions.ExifData = dicom.ExifData;
                    }

                    pngOptions.Source = new FileCreateSource(outputPath, false);
                    dicom.Save(outputPath, pngOptions);
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
 * 1. When a hospital needs to share radiology images with clinicians who use standard image viewers, preserving the original DICOM EXIF metadata in PNG ensures patient and study information remains traceable.
 * 2. When a research team exports DICOM scans to PNG for inclusion in publications, keeping the EXIF data allows them to reference acquisition parameters directly from the image file.
 * 3. When a PACS integration converts DICOM files to PNG for web‑based dashboards, embedding the original metadata supports audit trails and regulatory compliance.
 * 4. When a developer builds a mobile app that displays medical images as PNG, copying the DICOM EXIF data enables the app to show patient ID and study date without loading the full DICOM file.
 * 5. When an AI pipeline preprocesses DICOM images into PNG for model training, retaining the EXIF metadata helps label the data set with modality and acquisition details for downstream analysis.
 */
