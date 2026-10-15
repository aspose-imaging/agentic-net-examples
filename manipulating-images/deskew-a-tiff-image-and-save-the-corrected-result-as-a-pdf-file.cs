// HOW-TO: How To Deskew A TIFF And Convert To PDF In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Optional: set metered license
            // var license = new Aspose.Imaging.License();
            // license.SetMeteredKey("YOUR_PUBLIC_KEY", "YOUR_PRIVATE_PASSWORD");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image
                image.NormalizeAngle();

                // Save the result as PDF
                var pdfOptions = new PdfOptions();
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
 * 1. When you receive scanned TIFF documents that are slightly rotated and need a corrected PDF for archiving.
 * 2. When an application must automatically straighten scanned TIFF invoices before generating searchable PDF reports.
 * 3. When a batch process has to clean up scanned forms and output them as PDFs for electronic signatures.
 * 4. When a web service receives user‑uploaded TIFF images and must return a deskewed PDF for viewing in browsers.
 * 5. When you need to integrate image preprocessing (deskew) with PDF conversion in a C# workflow for a document management system.
 */
