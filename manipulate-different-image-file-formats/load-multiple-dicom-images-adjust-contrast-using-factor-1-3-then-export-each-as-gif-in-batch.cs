// HOW-TO: Batch Adjust Contrast of DICOM Images and Convert to GIF in C# (Aspose.Imaging for .NET)
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

namespace DicomBatchProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputDicom";
                string outputDirectory = @"C:\OutputGif";

                Directory.CreateDirectory(outputDirectory);

                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

                foreach (string inputPath in dicomFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                    {
                        dicomImage.AdjustContrast(1.3f);

                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        GifOptions gifOptions = new GifOptions();
                        dicomImage.Save(outputPath, gifOptions);
                    }
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
 * 1. When a radiology software needs to enhance the visibility of multiple DICOM scans and provide lightweight GIF previews for web viewers.
 * 2. When a medical research team wants to automatically process a folder of DICOM files, increase their contrast by a factor of 1.3, and store the results as GIFs for inclusion in reports.
 * 3. When a healthcare IT system must generate static GIF thumbnails from a batch of DICOM images after applying contrast correction for faster loading in patient portals.
 * 4. When a developer is building a bulk conversion tool that reads DICOM files from a directory, adjusts image contrast, and saves them as GIFs using Aspose.Imaging in a .NET application.
 * 5. When an imaging workflow requires converting high‑resolution DICOM images to smaller GIF files with enhanced contrast to reduce bandwidth for remote diagnostics.
 */
