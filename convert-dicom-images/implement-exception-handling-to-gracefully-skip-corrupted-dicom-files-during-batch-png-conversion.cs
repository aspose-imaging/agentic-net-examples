// HOW-TO: Batch Convert DICOM to PNG in C# While Skipping Corrupted Files (Aspose.Imaging for .NET)
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

namespace DicomBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = @"C:\Images\DICOM";
                string outputPath = @"C:\Images\PNG";

                string[] files = Directory.GetFiles(inputPath, "*.dcm", SearchOption.AllDirectories);
                foreach (string dicomFile in files)
                {
                    if (!File.Exists(dicomFile))
                    {
                        Console.Error.WriteLine($"File not found: {dicomFile}");
                        continue;
                    }

                    string relative = Path.GetRelativePath(inputPath, dicomFile);
                    string pngFile = Path.Combine(outputPath, Path.ChangeExtension(relative, ".png"));
                    Directory.CreateDirectory(Path.GetDirectoryName(pngFile));

                    try
                    {
                        using (Image image = Image.Load(dicomFile))
                        {
                            var options = new PngOptions();
                            image.Save(pngFile, options);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Failed to convert {dicomFile}: {ex.Message}");
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
 * 1. When a hospital needs to export thousands of DICOM scans to PNG for a web‑based viewer and some files may be damaged.
 * 2. When a research lab automates the creation of thumbnail PNGs from a large DICOM archive while ensuring the process continues despite corrupted entries.
 * 3. When a medical imaging vendor builds a batch conversion tool that must log and ignore unreadable DICOM files to avoid stopping the entire job.
 * 4. When a radiology department migrates legacy DICOM data to cloud‑friendly PNG format and requires graceful error handling for incomplete files.
 * 5. When a developer creates a scheduled service that converts incoming DICOM files to PNG for downstream AI analysis and needs to skip files that cannot be loaded.
 */
