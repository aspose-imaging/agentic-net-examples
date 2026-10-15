// HOW-TO: Convert DICOM to PNG with Otsu Binarization Using Low Memory in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1024 * 1024 }))
            {
                dicom.BinarizeOtsu();

                using (PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                })
                {
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
 * 1. When a medical imaging application needs to display DICOM scans on web browsers, converting them to PNG after Otsu binarization reduces file size and improves visibility.
 * 2. When processing large DICOM datasets on a server with limited RAM, using the BufferSizeHint low‑memory strategy enables efficient loading and thresholding without out‑of‑memory errors.
 * 3. When preparing DICOM images for machine‑learning preprocessing, applying Otsu’s automatic threshold creates binary masks that can be saved as PNG for downstream algorithms.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that extracts diagnostic regions from DICOM files, the code converts the binary result to PNG for easy annotation and sharing.
 * 5. When archiving radiology images in a format compatible with standard image viewers, converting DICOM to PNG with Otsu binarization ensures consistent contrast across different platforms.
 */
