// HOW-TO: Resize Image to 2000 Pixels Width and Convert to PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "source.png");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                int newWidth = originalWidth;
                int newHeight = originalHeight;

                if (originalWidth > 2000)
                {
                    newWidth = 2000;
                    newHeight = (int)Math.Round((double)originalHeight * 2000 / originalWidth);
                }

                if (newWidth != originalWidth || newHeight != originalHeight)
                {
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                }

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
 * 1. When you need to shrink a high‑resolution PNG to a printable size of 2000 px width before generating a PDF for large‑format posters.
 * 2. When an e‑commerce platform must automatically resize user‑uploaded product photos and bundle them into a single PDF catalog.
 * 3. When a document workflow requires converting raster images to PDF while preserving aspect ratio to avoid distortion in printouts.
 * 4. When a printing service wants to ensure all images fit within a 2000‑pixel width limit to reduce PDF file size and improve rendering speed.
 * 5. When a C# application processes scanned images, resizes them for consistent layout, and saves the result as a PDF for archival.
 */
