// HOW-TO: Batch Convert TIFF Files To JPEG With 90% Quality In C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(file))
                {
                    JpegOptions jpegOptions = new JpegOptions { Quality = 90 };
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted {file} to {outputPath}");
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
 * 1. When you need to automatically transform a folder of scanned TIFF documents into smaller JPEG images for web publishing.
 * 2. When you want to create a nightly job that compresses high‑resolution TIFF files to 90 % quality JPEGs to save storage space.
 * 3. When you are building a migration tool that reads legacy TIFF assets and outputs JPEGs while keeping a log of each conversion.
 * 4. When you must prepare a batch of medical or engineering TIFF images for a client application that only supports JPEG format.
 * 5. When you require a simple C# script to process incoming TIFF uploads, convert them to JPEG with consistent quality, and store the results in a separate directory.
 */
