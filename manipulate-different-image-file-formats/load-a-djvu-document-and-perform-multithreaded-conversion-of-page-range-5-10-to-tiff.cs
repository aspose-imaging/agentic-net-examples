// HOW-TO: Convert DjVu Pages 5 to 10 to TIFF Using Multithreading in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
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
            string inputPath = "Input/document.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            var tasks = new Task[6];
            int taskIndex = 0;
            for (int page = 5; page <= 10; page++)
            {
                int currentPage = page;
                tasks[taskIndex++] = Task.Run(() =>
                {
                    using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                    {
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(currentPage, currentPage));

                        string outputPath = Path.Combine(outputDirectory, $"page_{currentPage}.tif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        djvu.Save(outputPath, tiffOptions);
                    }
                });
            }

            Task.WaitAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific range of pages from a DjVu document and save each page as a separate TIFF file for archival or printing.
 * 2. When you want to speed up batch conversion of DjVu pages by processing multiple pages concurrently on a multi‑core server.
 * 3. When an application must generate high‑resolution TIFF images from DjVu source files for OCR or image analysis pipelines.
 * 4. When a document management system requires individual TIFF files for pages 5‑10 of a DjVu file to comply with legacy workflow tools.
 * 5. When you need to programmatically create TIFF files from DjVu pages while handling missing input files and ensuring output folders exist.
 */
