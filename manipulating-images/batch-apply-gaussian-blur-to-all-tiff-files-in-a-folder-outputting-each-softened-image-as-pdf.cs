// HOW-TO: How to Batch Blur TIFF Images and Save as PDF Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            foreach (string filePath in files)
            {
                string ext = Path.GetExtension(filePath);
                if (!string.Equals(ext, ".tif", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(ext, ".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Image image = Image.Load(filePath))
                using (RasterImage raster = (RasterImage)image)
                {
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions());

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to automatically soften scanned TIFF documents before converting them into searchable PDF reports in a .NET batch process.
 * 2. When a medical imaging system must apply a Gaussian blur to a folder of DICOM‑exported TIFF files and archive the results as PDFs for patient records.
 * 3. When a publishing workflow requires mass‑processing of high‑resolution TIFF artwork, adding a blur effect and delivering the final pages as PDF files.
 * 4. When an archival tool has to clean up noisy TIFF scans by blurring them and then store the cleaned images in PDF format for easier distribution.
 * 5. When a C# application must iterate over a directory of TIFF files, apply a Gaussian filter, and generate PDF versions for integration with document management systems.
 */
