// HOW-TO: Resize PNG with Lanczos Resampling and Save as PDF in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPdfPath = "output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                var pdfOptions = new PdfOptions();
                image.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to shrink large PNG graphics for email attachments while preserving visual quality by using Lanczos resampling before embedding them in a PDF report.
 * 2. When generating printable PDF catalogs from high‑resolution raster images and want to reduce file size by resizing the images at half their original dimensions.
 * 3. When a web application creates PDFs on the fly and must downscale user‑uploaded images to meet layout constraints without losing sharpness.
 * 4. When automating batch conversion of PNG assets to PDF documents and require a consistent high‑quality resize algorithm for all files.
 * 5. When integrating Aspose.Imaging into a C# service that prepares marketing materials, ensuring each image is resized with Lanczos and saved directly as a PDF for distribution.
 */
