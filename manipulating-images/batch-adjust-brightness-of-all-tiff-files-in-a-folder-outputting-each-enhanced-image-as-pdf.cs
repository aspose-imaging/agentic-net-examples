// HOW-TO: Batch Increase Brightness of TIFF Images and Convert to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.tif*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
                {
                    foreach (TiffFrame frame in tiff.Frames)
                    {
                        tiff.ActiveFrame = frame;
                        RasterImage raster = (RasterImage)frame;
                        raster.AdjustBrightness(30);
                    }

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        tiff.Save(outputPath, pdfOptions);
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
 * 1. When you need to improve the visibility of scanned documents stored as multi‑page TIFFs before archiving them as searchable PDFs.
 * 2. When a medical imaging system outputs TIFF scans that require a uniform brightness boost before being shared with clinicians in PDF format.
 * 3. When a publishing workflow must automatically brighten a batch of high‑resolution TIFF artwork files and deliver them as PDF proofs.
 * 4. When a legal office wants to enhance the legibility of TIFF‑based evidence files and convert each file to a PDF for court submission.
 * 5. When a cloud service processes user‑uploaded TIFF photos, applies a brightness correction, and stores the results as PDFs for easy viewing.
 */
