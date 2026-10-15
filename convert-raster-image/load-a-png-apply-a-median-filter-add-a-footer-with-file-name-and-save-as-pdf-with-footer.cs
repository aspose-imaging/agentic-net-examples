// HOW-TO: Add Filename Footer to PNG and Save as PDF with Median Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Black))
                {
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                    graphics.DrawString(Path.GetFileName(inputPath), font, brush, new Aspose.Imaging.Point(10, raster.Height - 30));
                }

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to clean up a scanned PNG image, add a descriptive label, and generate a searchable PDF report.
 * 2. When automating batch conversion of product photos to PDFs while applying noise reduction and embedding the original file name as a caption.
 * 3. When creating archival PDFs from PNG receipts that require median filtering to remove speckles and a footer for audit trails.
 * 4. When building a C# service that receives PNG uploads, applies a median filter for quality improvement, and returns a PDF with the source name displayed.
 * 5. When preparing marketing assets where each PNG must be filtered, watermarked with its filename, and delivered as a PDF for client review.
 */
