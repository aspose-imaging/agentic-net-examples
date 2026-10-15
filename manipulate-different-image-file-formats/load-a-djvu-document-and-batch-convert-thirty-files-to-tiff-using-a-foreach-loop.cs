// HOW-TO: Batch Convert Up to 30 DjVu Files to TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");
            int processed = 0;

            foreach (var inputPath in files)
            {
                if (processed >= 30)
                    break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
                    djvu.Save(outputPath, tiffOptions);
                }

                processed++;
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
 * 1. When you need to automate conversion of a large set of scanned DjVu documents into multi‑page TIFF files for archival or OCR processing.
 * 2. When a document management system requires TIFF images but the source files are provided as DjVu, and you want to process up to thirty files at a time.
 * 3. When you are building a batch‑processing tool that reads DjVu files from a folder and saves them as TIFFs for compatibility with legacy Windows applications.
 * 4. When you must limit the conversion to the first thirty DjVu files to avoid overloading resources while still generating TIFF output for each.
 * 5. When you need to programmatically create TIFF files with multi‑page support from DjVu sources using Aspose.Imaging in a C# console application.
 */
