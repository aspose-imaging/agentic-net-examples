// HOW-TO: Apply Median Filter to Raster Images and Save as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Not a raster image: {inputPath}");
                        return;
                    }

                    var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                    raster.Filter(raster.Bounds, medianOptions);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑process scanned TIFF or JPEG files, apply a median noise‑reduction filter, and deliver each cleaned page as a PDF report from a C# web service.
 * 2. When an automated document pipeline must convert a folder of raster graphics (PNG, BMP) into searchable PDFs after smoothing out speckles using a 3×3 median filter.
 * 3. When a desktop application has to quickly improve image quality of user‑uploaded photos and export the results as PDF invoices without manual editing.
 * 4. When a background job processes medical imaging slices (e.g., DICOM converted to PNG) to remove salt‑and‑pepper noise before archiving them as PDFs for electronic health records.
 * 5. When a content‑management system needs to generate PDF previews of uploaded raster artwork, applying a median filter to ensure consistent visual quality across browsers.
 */
