// HOW-TO: Watch Folder for New DICOM Files and Convert to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string watchFolder = @"C:\InputDICOM";
            string outputFolder = @"C:\OutputPNG";

            // Ensure the watch folder exists
            if (!Directory.Exists(watchFolder))
            {
                Console.Error.WriteLine($"Watch folder not found: {watchFolder}");
                return;
            }

            // Set up FileSystemWatcher
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = watchFolder,
                Filter = "*.dcm",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            watcher.Created += (sender, e) =>
            {
                // Small delay to ensure file is fully written
                Thread.Sleep(500);

                string inputPath = e.FullPath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                    {
                        PngOptions pngOptions = new PngOptions();
                        dicomImage.Save(outputPath, pngOptions);
                        Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error converting file '{inputPath}': {ex.Message}");
                }
            };

            // Keep the application running
            Console.WriteLine("Monitoring folder for new DICOM files. Press Enter to exit.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital’s PACS system needs an automated process that watches a drop‑folder and turns incoming DICOM scans into PNGs for quick web preview.
 * 2. When a research lab wants a background Windows service that detects newly saved DICOM images and creates PNG thumbnails for inclusion in reports.
 * 3. When a tele‑medicine application must instantly convert patient DICOM files placed in a shared directory to PNG so they can be displayed in a browser without additional plugins.
 * 4. When a radiology workflow requires a C# service that monitors a folder, loads each DICOM with Aspose.Imaging, and saves a lossless PNG for archival or AI analysis.
 * 5. When a developer needs to integrate file‑system monitoring with Aspose.Imaging to automatically generate PNG assets from incoming DICOM files for a medical imaging dashboard.
 */
