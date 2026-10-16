// HOW-TO: Convert DICOM Image to PNG with Automatic Disposal in C# (Aspose.Imaging for .NET)
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

namespace DicomToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output\\output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to display DICOM scans in a web browser that only supports PNG, this code converts the file and releases resources automatically.
 * 2. When integrating a PACS system with a reporting tool that requires PNG thumbnails, developers can use this snippet to generate the thumbnails safely.
 * 3. When building a data‑pipeline that extracts diagnostic images from DICOM files and stores them as PNG for machine‑learning preprocessing, the code ensures proper memory cleanup.
 * 4. When creating a desktop utility that lets radiologists export selected DICOM studies to PNG for patient records, the using statement guarantees the Image object is disposed after saving.
 * 5. When automating batch conversion of a folder of DICOM files to PNG on a server, this pattern prevents file‑handle leaks and improves reliability.
 */
