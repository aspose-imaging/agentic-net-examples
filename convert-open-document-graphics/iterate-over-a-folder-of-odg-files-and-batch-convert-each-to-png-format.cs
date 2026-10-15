// HOW-TO: Batch Convert ODG Files to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

namespace OdgBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "InputOdgs";
                string outputFolder = "OutputPngs";

                string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in odgFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        PngOptions options = new PngOptions();
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to automatically transform a collection of OpenDocument graphics (ODG) drawings into web‑ready PNG images for a website gallery.
 * 2. When a document management system must export user‑uploaded ODG diagrams to PNG format for preview thumbnails.
 * 3. When a migration script has to convert legacy ODG assets stored in a directory to PNG to integrate with a new .NET application.
 * 4. When an automated build process should generate PNG versions of ODG files for inclusion in PDF reports or presentations.
 * 5. When a desktop utility must process dozens of ODG files in a folder and save each as a lossless PNG without manual intervention.
 */
