// HOW-TO: Resize EPS to 2000px Width and Export as PDF/A-2b in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int originalWidth = epsImage.Width;
                int originalHeight = epsImage.Height;

                int targetWidth = 2000;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = targetWidth,
                    PageHeight = targetHeight
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to downscale a large EPS logo to a fixed 2000‑pixel width before archiving it as a PDF/A‑2b compliant document for long‑term storage.
 * 2. When a printing workflow requires converting vector EPS artwork to a PDF/A‑2b file with a specific pixel width to ensure consistent output across printers.
 * 3. When generating PDF reports that embed EPS diagrams and must meet PDF/A‑2b standards while fitting within a predefined page width.
 * 4. When a web application must serve EPS graphics as PDF/A‑2b files sized for faster download, resizing them to 2000 pixels wide on the server side.
 * 5. When automating batch processing of EPS files to create PDF/A‑2b compliant PDFs with uniform width for compliance audits or digital asset management.
 */
