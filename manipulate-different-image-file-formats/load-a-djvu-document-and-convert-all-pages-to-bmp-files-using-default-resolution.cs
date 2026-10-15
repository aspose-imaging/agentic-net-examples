// HOW-TO: Convert All DjVu Pages to BMP Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    BmpOptions options = new BmpOptions();
                    options.MultiPageOptions = new DjvuMultiPageOptions(i);
                    djvu.Save(outputPath, options);
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
 * 1. When you need to extract each page of a multi‑page DjVu document as separate BMP files for legacy Windows applications.
 * 2. When an archival workflow requires converting scanned DjVu files to BMP format to preserve pixel‑perfect fidelity before further processing.
 * 3. When a batch job must generate bitmap thumbnails from DjVu pages for use in a document management system that only supports BMP.
 * 4. When integrating Aspose.Imaging into a C# service that transforms DjVu reports into BMP images for printing on devices that accept only BMP.
 * 5. When automating the migration of DjVu e‑books to BMP images to ensure compatibility with older image viewers that cannot read DjVu.
 */
