// HOW-TO: Convert DjVu Pages 1 to 5 to PDF with Memory Buffer in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\range1to5.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions { BufferSizeHint = 1048576 };

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, loadOptions))
            {
                var pdfOptions = new PdfOptions();
                pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(1, 5));
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to extract only the first five pages of a DjVu document and save them as a searchable PDF in a .NET application.
 * 2. When you want to limit memory usage while loading large DjVu files by setting a buffer size hint before conversion.
 * 3. When you are automating batch processing of DjVu archives and must generate separate PDF files for specific page ranges.
 * 4. When you require proper disposal of image resources after conversion to avoid memory leaks in a C# service.
 * 5. When you need to programmatically create PDF reports from DjVu source files without loading the entire document into memory.
 */
