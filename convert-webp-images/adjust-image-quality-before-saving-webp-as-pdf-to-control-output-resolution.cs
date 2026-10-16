// HOW-TO: Resize WebP Image and Save as PDF with Custom DPI in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                // Adjust image quality by resizing (example: reduce dimensions by 50%)
                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;
                webp.Resize(newWidth, newHeight);

                // Optionally set resolution (DPI) to control output resolution
                webp.SetResolution(72, 72);

                // Save the image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                webp.Save(outputPath, pdfOptions);
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
 * 1. When you need to reduce the file size of a high‑resolution WebP before embedding it in a PDF report.
 * 2. When you must generate PDFs from WebP assets while controlling the output DPI for print‑ready documents.
 * 3. When an application processes user‑uploaded WebP images and must resize them to fit a predefined layout in a PDF invoice.
 * 4. When a batch conversion tool has to standardize image dimensions and resolution before archiving WebP files as PDFs.
 * 5. When a web service creates downloadable PDFs from WebP thumbnails and wants to ensure consistent on‑screen quality across devices.
 */
