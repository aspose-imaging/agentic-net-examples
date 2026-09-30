// HOW-TO: Automatically Convert New DICOM Files to PNG in C# Background Service (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-29
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            void ConvertDicomToPng(string inputPath)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    dicom.Save(outputPath, pngOptions);
                }

                Console.WriteLine($"Converted {inputPath} to {outputPath}");
            }

            // Process existing DICOM files
            foreach (string file in Directory.GetFiles(inputFolder, "*.dcm"))
            {
                ConvertDicomToPng(file);
            }

            // Watch for new DICOM files
            using (FileSystemWatcher watcher = new FileSystemWatcher(inputFolder, "*.dcm"))
            {
                watcher.Created += (s, e) => ConvertDicomToPng(e.FullPath);
                watcher.EnableRaisingEvents = true;

                // Bounded wait to keep the service alive briefly
                Task.Delay(5000).Wait();
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
 * 1. When a medical imaging system needs to generate PNG previews of incoming DICOM scans for web display.
 * 2. When a hospital PACS workflow requires automatic conversion of saved DICOM files to PNG for integration with reporting tools.
 * 3. When a research lab wants to monitor a folder where MRI machines drop DICOM files and instantly produce PNG images for analysis scripts.
 * 4. When a cloud service ingests DICOM uploads and must create PNG thumbnails on the fly without manual intervention.
 * 5. When a desktop application must watch a directory for new radiology images and store them as PNG for archival or sharing.
 */
