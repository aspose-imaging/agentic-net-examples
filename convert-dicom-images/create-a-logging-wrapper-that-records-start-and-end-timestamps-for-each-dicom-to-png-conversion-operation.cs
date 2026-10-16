// HOW-TO: Log Start and End Times for DICOM to PNG Conversion in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add DICOM files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                DateTime start = DateTime.Now;
                Console.WriteLine($"Starting conversion: {inputPath} at {start}");

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    using (var pngOptions = new PngOptions())
                    {
                        dicom.Save(outputPath, pngOptions);
                    }
                }

                DateTime end = DateTime.Now;
                Console.WriteLine($"Finished conversion: {outputPath} at {end}");
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
 * 1. When a hospital IT system needs to batch‑convert DICOM scans to PNG while keeping an audit log of each conversion’s start and finish times.
 * 2. When a developer wants to monitor performance of image‑processing pipelines by recording timestamps for every DICOM to PNG transformation.
 * 3. When regulatory compliance requires a timestamped record of every medical image conversion for traceability.
 * 4. When a research project processes large numbers of DICOM files and needs to identify slow or failed conversions by reviewing logged start and end times.
 * 5. When integrating Aspose.Imaging into a C# application and you need a simple console‑based wrapper that reports when each DICOM file begins and completes conversion to PNG.
 */
