// HOW-TO: Batch Convert DICOM to PNG with Gamma Adjustment in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 10 * 1024 * 1024 };

                using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
                {
                    image.AdjustGamma(1.2f);
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to process a folder of medical DICOM scans, apply gamma correction, and export each image as a PNG for easy viewing in browsers.
 * 2. When you want to load large DICOM files using a memory‑efficient buffer size hint before converting them to a smaller PNG format.
 * 3. When integrating a C# application with a PACS system and you must transform received DICOM images into PNGs for inclusion in clinical reports.
 * 4. When building an automated pipeline that normalizes the brightness of radiology images and saves them as lossless PNGs for archival purposes.
 * 5. When preparing DICOM datasets for a machine‑learning workflow that requires PNG input with consistent gamma settings.
 */
