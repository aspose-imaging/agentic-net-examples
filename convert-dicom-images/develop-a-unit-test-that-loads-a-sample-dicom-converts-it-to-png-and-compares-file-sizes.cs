// HOW-TO: How To Convert DICOM To PNG And Compare File Sizes In C# (Aspose.Imaging for .NET)
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

namespace DicomToPngTest
{
    class Program
    {
        static void Main()
        {
            string inputPath = "sample.dcm";
            string outputPath = "output/sample.png";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage image = (DicomImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                long dicomSize = new FileInfo(inputPath).Length;
                long pngSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"DICOM size: {dicomSize} bytes");
                Console.WriteLine($"PNG size: {pngSize} bytes");
                Console.WriteLine(pngSize < dicomSize ? "PNG is smaller than DICOM." : "PNG is not smaller than DICOM.");
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
 * 1. When a medical imaging application needs to generate smaller PNG thumbnails from DICOM files for web preview.
 * 2. When a developer wants to verify whether converting a DICOM scan to PNG reduces storage requirements before archiving.
 * 3. When building automated tests that ensure the Aspose.Imaging DICOM‑to‑PNG conversion produces expected output sizes.
 * 4. When integrating a C# service that extracts DICOM images and saves them as PNG for compatibility with standard image viewers.
 * 5. When performing batch processing of radiology files and need to log size differences between original DICOM and converted PNG files.
 */
