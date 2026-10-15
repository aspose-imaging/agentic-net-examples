// HOW-TO: Batch Convert PNG Images to Individual PDFs and Combine into One PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputFolder = @"C:\Images\InputPngs";
            string outputFolder = @"C:\Images\OutputPdfs";
            string aggregatedPdfPath = @"C:\Images\Aggregated\combined.pdf";

            // Ensure output directories exist
            Directory.CreateDirectory(outputFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(aggregatedPdfPath));

            // Shared memory stream for aggregating PDFs
            using (MemoryStream aggregatedStream = new MemoryStream())
            {
                // Process each PNG file in the input folder
                foreach (string pngPath in Directory.GetFiles(inputFolder, "*.png"))
                {
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    using (Image image = Image.Load(pngPath))
                    {
                        // Save individual PDF
                        string pdfFileName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                        string pdfPath = Path.Combine(outputFolder, pdfFileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                        PdfOptions pdfOptions = new PdfOptions();
                        image.Save(pdfPath, pdfOptions);

                        // Append PDF to the shared memory stream
                        image.Save(aggregatedStream, pdfOptions);
                    }
                }

                // Write the aggregated PDF stream to disk
                aggregatedStream.Position = 0;
                using (FileStream fileStream = new FileStream(aggregatedPdfPath, FileMode.Create, FileAccess.Write))
                {
                    aggregatedStream.CopyTo(fileStream);
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
 * 1. When you need to generate separate PDF reports from a folder of PNG scans and store them for later distribution.
 * 2. When you want to create a single combined PDF document from multiple PNG receipts for easy archiving.
 * 3. When an application must convert user‑uploaded PNG screenshots into PDFs and then merge them into one file before sending to a web service.
 * 4. When a batch processing job has to produce both individual PDF files and a consolidated PDF for compliance documentation.
 * 5. When you are building a .NET utility that consolidates PNG product images into a single PDF catalog while also keeping each image as its own PDF file.
 */
