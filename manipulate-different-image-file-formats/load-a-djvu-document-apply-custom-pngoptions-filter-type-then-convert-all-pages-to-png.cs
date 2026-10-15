// HOW-TO: Convert DjVu Document Pages to PNG with Sub Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

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
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions options = new PngOptions())
                    {
                        options.FilterType = PngFilterType.Sub;
                        options.MultiPageOptions = new DjvuMultiPageOptions(i);
                        djvu.Save(outputPath, options);
                    }
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑quality PNG images for web preview, you can use this code.
 * 2. When archiving scanned documents originally stored as DjVu, converting them to PNG with a specific filter helps maintain visual fidelity while making them compatible with standard image viewers.
 * 3. When building a document‑processing pipeline that must batch‑convert DjVu pages to PNG for OCR preprocessing, this snippet automates the per‑page conversion with custom PNG options.
 * 4. When a client requires DjVu pages to be delivered as separate PNG files with the Sub filter to reduce file size without losing detail, the example provides a ready‑to‑use solution.
 * 5. When integrating Aspose.Imaging into a C# application to programmatically render DjVu content as PNG thumbnails for a document management system, this code demonstrates the necessary steps.
 */
