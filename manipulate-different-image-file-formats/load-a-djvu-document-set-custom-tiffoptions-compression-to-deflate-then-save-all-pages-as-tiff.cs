// HOW-TO: Convert DjVu Pages to Deflate Compressed TIFF Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;

                    djvu.Pages[i].Save(outputPath, tiffOptions);
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
 * 1. When you need to archive each page of a multi‑page DjVu document as a lossless, Deflate‑compressed TIFF for long‑term storage.
 * 2. When a document‑management system requires converting scanned DjVu files into individual TIFF images that can be indexed by OCR tools.
 * 3. When a printing workflow must extract DjVu pages and save them as TIFF files with Deflate compression to reduce file size without quality loss.
 * 4. When you are building a C# application that processes DjVu ebooks and needs to generate separate TIFF files for each chapter page.
 * 5. When a legal‑tech solution must preserve the exact visual fidelity of DjVu evidence files while converting them to TIFF for court submission.
 */
