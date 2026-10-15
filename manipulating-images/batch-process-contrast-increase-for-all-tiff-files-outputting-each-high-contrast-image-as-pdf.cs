// HOW-TO: Batch Increase Contrast of TIFF Images and Save as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = @"C:\InputTiffs";
            string outputDir = @"C:\OutputPdfs";

            string[] tiffFiles1 = Directory.GetFiles(inputDir, "*.tif");
            string[] tiffFiles2 = Directory.GetFiles(inputDir, "*.tiff");
            var allFiles = new List<string>();
            allFiles.AddRange(tiffFiles1);
            allFiles.AddRange(tiffFiles2);

            foreach (var inputPath in allFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        raster.AdjustContrast(50);
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to automatically enhance the visual clarity of a large collection of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When a medical imaging workflow requires batch processing of radiology TIFF files to improve contrast and convert them to PDF for easier distribution to clinicians.
 * 3. When a legal firm wants to increase the readability of multi‑page TIFF contracts and output each file as a PDF for client review.
 * 4. When a printing service must prepare high‑contrast TIFF artwork for PDF preview without manually editing each image.
 * 5. When an automated document management system needs to standardize incoming TIFF scans by adjusting contrast and storing them in PDF format for long‑term storage.
 */
