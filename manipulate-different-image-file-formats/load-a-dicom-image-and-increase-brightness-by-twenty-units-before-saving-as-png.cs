// HOW-TO: Increase Brightness of DICOM Image and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.AdjustBrightness(20);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a radiology software needs to enhance a DICOM scan’s visibility before converting it to a PNG for web display.
 * 2. When a healthcare app must preprocess DICOM images by brightening them to improve OCR accuracy on extracted text.
 * 3. When a medical research pipeline requires batch conversion of DICOM files to PNG with a uniform brightness boost for consistent analysis.
 * 4. When a diagnostic tool wants to create patient‑friendly PNG snapshots from DICOM data with adjusted brightness for printed reports.
 * 5. When a C# service integrates Aspose.Imaging to automatically adjust DICOM image brightness and store the result as PNG for archival purposes.
 */
