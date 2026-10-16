// HOW-TO: Asynchronously Convert DICOM Files To PNG In C# Using Task.Run (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace DicomToPngConverter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output\\converted.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                await Task.Run(() =>
                {
                    using (Image image = Image.Load(inputPath))
                    {
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                });
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
 * 1. When a medical imaging application needs to display DICOM scans as PNG thumbnails without freezing the UI.
 * 2. When a radiology web service must batch‑convert incoming DICOM studies to PNG for browser‑compatible viewing.
 * 3. When a desktop tool processes patient scans and saves them as PNG files while keeping the UI responsive for other tasks.
 * 4. When an automated pipeline extracts DICOM images and stores them as PNG for integration with non‑medical image libraries.
 * 5. When a Windows Forms or WPF application allows users to select a DICOM file and instantly see a PNG preview without blocking the main thread.
 */
