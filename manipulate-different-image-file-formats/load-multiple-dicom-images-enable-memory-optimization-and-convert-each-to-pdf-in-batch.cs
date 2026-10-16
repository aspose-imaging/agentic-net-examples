// HOW-TO: Batch Convert DICOM Images to PDF with Memory Optimization in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!inputPath.EndsWith(".dcm", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                var loadOptions = new LoadOptions { BufferSizeHint = 1024 * 1024 };
                using (DicomImage dicom = (DicomImage)Image.Load(inputPath, loadOptions))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    string outDir = Path.GetDirectoryName(outputPath);
                    Directory.CreateDirectory(outDir);

                    using (var pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        dicom.Save(outputPath, pdfOptions);
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
 * 1. When a hospital needs to archive a folder of DICOM scans as PDF reports while keeping server memory usage low.
 * 2. When medical imaging software must process large batches of radiology DICOM files and generate PDF files for patient records.
 * 3. When a research lab wants to convert thousands of DICOM images to PDF for easy sharing without exhausting RAM.
 * 4. When a cloud service automates the transformation of incoming DICOM uploads into PDF documents for downstream workflow.
 * 5. When a developer builds a desktop utility that reads DICOM files from a directory, optimizes loading, and saves each as a PDF for printing.
 */
