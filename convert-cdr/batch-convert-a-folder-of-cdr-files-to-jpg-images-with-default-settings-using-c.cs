// HOW-TO: Batch Convert CDR Files to JPG Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace BatchCdrToJpg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "C:\\InputCdr";
                string outputFolder = "C:\\OutputJpg";

                Directory.CreateDirectory(outputFolder);

                string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr", SearchOption.TopDirectoryOnly);
                foreach (string inputPath in cdrFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        JpegOptions options = new JpegOptions();
                        image.Save(outputPath, options);
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
 * 1. When a graphic design studio needs to automatically turn a collection of CorelDRAW (.cdr) assets into web‑ready JPEGs for publishing.
 * 2. When a migration script must process dozens of legacy CDR files stored in a directory and output JPEG thumbnails for a content management system.
 * 3. When an e‑commerce platform wants to generate product preview images from CDR source files without manual intervention.
 * 4. When a Windows service has to batch convert newly uploaded CDR drawings to JPG format for email attachments or reporting.
 * 5. When a developer integrates Aspose.Imaging into a .NET tool to streamline bulk image conversion from vector CDR files to raster JPEGs with default quality settings.
 */
