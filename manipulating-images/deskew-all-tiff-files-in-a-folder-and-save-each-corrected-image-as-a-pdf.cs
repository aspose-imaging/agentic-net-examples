// HOW-TO: Batch Deskew TIFF Images and Convert to PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputTiffFolder";
            string outputFolder = @"C:\OutputPdfFolder";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in tiffFiles)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, deskew, and save as PDF
                using (Image image = Image.Load(filePath))
                {
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.NormalizeAngle();
                        PdfOptions pdfOptions = new PdfOptions();
                        rasterImage.Save(outputPath, pdfOptions);
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {filePath}");
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
 * 1. When you need to automatically correct the orientation of scanned documents stored as TIFF files and produce PDF versions for archiving.
 * 2. When a batch of scanned invoices in a folder must be deskewed before converting them to PDF for electronic workflow integration.
 * 3. When a document management system requires converting multi‑page TIFF scans to PDF while ensuring each page is properly aligned using C#.
 * 4. When you want to preprocess a collection of TIFF images from a scanner, remove skew, and generate PDF files for easy distribution to clients.
 * 5. When a legal or medical records application must normalize the angle of TIFF scans and save them as PDFs for compliance and viewing on any device.
 */
