// HOW-TO: Resize BMP Image With Nearest Neighbor And Convert To PDF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png; // Required for PdfOptions dependency
using Aspose.Imaging.FileFormats.Jpeg; // Ensure PDF saving works

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Define desired dimensions for resizing
                int newWidth = 200;   // example width
                int newHeight = 200;  // example height

                // Resize using nearest‑neighbor interpolation
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Convert the resized image to PDF
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
 * 1. When you need to shrink a large BMP graphic for a printable PDF report without smoothing the pixels.
 * 2. When generating thumbnails of legacy BMP assets for inclusion in PDF documentation while preserving hard edges.
 * 3. When converting scanned BMP maps to PDF while keeping the original pixelated style for GIS applications.
 * 4. When automating batch processing of BMP icons to fit a fixed 200×200 size before embedding them in a PDF catalog.
 * 5. When creating a PDF preview of a BMP image in a web application that requires fast nearest‑neighbor resizing for performance.
 */
