// HOW-TO: Increase TIFF Image Contrast by 30% and Save as PDF in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.tif";
        string outputPath = "Output\\result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustContrast(30f);

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to enhance the visibility of scanned documents stored as TIFF files before distributing them as PDF reports.
 * 2. When a web application must automatically improve the contrast of uploaded TIFF images and deliver the results in a PDF format for easier viewing.
 * 3. When a batch processing script has to prepare high‑contrast PDFs from legacy TIFF archives for archival or compliance purposes.
 * 4. When a desktop utility needs to adjust the contrast of medical imaging TIFF files and export them as PDFs for patient records.
 * 5. When an automated workflow requires converting low‑contrast TIFF graphics to printable PDFs with a 30 percent contrast boost using Aspose.Imaging in C#.
 */
