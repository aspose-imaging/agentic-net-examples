// HOW-TO: Batch Convert TIFF Files to JPEG While Keeping Original Filenames in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions();
                    tiff.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert a folder of scanned TIFF documents to smaller JPEG files for web publishing while retaining the original document names.
 * 2. When an automated workflow must process multiple high‑resolution TIFF images and output JPEGs for faster loading in mobile applications.
 * 3. When a legacy system stores medical images as TIFF and you must generate JPEG thumbnails for a patient portal without changing the naming scheme.
 * 4. When a batch image‑processing script has to read TIFF files, apply Aspose.Imaging conversion, and save them as JPEGs in a separate output directory.
 * 5. When you want to programmatically migrate archival TIFF assets to JPEG format in C# while preserving each file’s base name for easy reference.
 */
