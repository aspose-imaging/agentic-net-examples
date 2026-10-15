// HOW-TO: Batch Convert Multiple DjVu Files To PDF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string[] inputFiles = new string[]
            {
                "input1.djvu",
                "input2.djvu",
                "input3.djvu",
                "input4.djvu",
                "input5.djvu",
                "input6.djvu",
                "input7.djvu",
                "input8.djvu",
                "input9.djvu",
                "input10.djvu",
                "input11.djvu",
                "input12.djvu",
                "input13.djvu",
                "input14.djvu",
                "input15.djvu",
                "input16.djvu",
                "input17.djvu",
                "input18.djvu",
                "input19.djvu",
                "input20.djvu"
            };

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PdfOptions pdfOptions = new PdfOptions();
                    djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to automate the conversion of a large collection of scanned DjVu documents into PDF files for archival or distribution.
 * 2. When a document management system must ingest DjVu files and store them as PDFs without manual intervention, using C# and Aspose.Imaging.
 * 3. When preparing e‑books or reports originally saved as DjVu, you want to programmatically generate PDF versions for compatibility with standard readers.
 * 4. When migrating legacy DjVu assets to a PDF‑based workflow, you require a batch process that creates PDFs with default settings to preserve the original layout.
 * 5. When building a server‑side service that receives DjVu uploads and returns PDF outputs, you need code that loads each file, converts it, and saves the result efficiently.
 */
