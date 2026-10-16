// HOW-TO: Resize DICOM Image to 800x600 and Convert to PNG in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input\\input.dcm";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                int newWidth = 800;
                int newHeight = 600;

                image.Resize(newWidth, newHeight);

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to generate smaller PNG thumbnails from large DICOM scans for faster web display.
 * 2. When a hospital PACS system must export patient scans as PNG files with a fixed resolution for inclusion in electronic health records.
 * 3. When a research tool requires batch conversion of DICOM images to PNG while standardizing them to 800×600 pixels for machine‑learning preprocessing.
 * 4. When a mobile health app needs to reduce the size of DICOM images before sending them over limited‑bandwidth networks as PNG attachments.
 * 5. When a diagnostic reporting workflow wants to embed resized PNG snapshots of DICOM studies into PDF reports generated in C#.
 */
