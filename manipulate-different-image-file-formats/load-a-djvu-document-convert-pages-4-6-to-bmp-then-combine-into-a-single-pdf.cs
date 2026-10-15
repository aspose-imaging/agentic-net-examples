// HOW-TO: Convert DjVu Pages 4 to 6 to BMP and Merge into PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDjvuPath = "input.djvu";
            if (!File.Exists(inputDjvuPath))
            {
                Console.Error.WriteLine($"File not found: {inputDjvuPath}");
                return;
            }

            string[] bmpPaths = new string[]
            {
                "page4.bmp",
                "page5.bmp",
                "page6.bmp"
            };

            // Ensure output directories for BMP files exist
            foreach (var bmpPath in bmpPaths)
            {
                string bmpDir = Path.GetDirectoryName(bmpPath);
                if (!string.IsNullOrWhiteSpace(bmpDir))
                {
                    Directory.CreateDirectory(bmpDir);
                }
            }

            // Load DjVu and export pages 4-6 (0‑based indices 3,4,5) to BMP
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputDjvuPath))
            {
                for (int i = 0; i < bmpPaths.Length; i++)
                {
                    int pageIndex = 3 + i; // pages 4,5,6
                    if (pageIndex < 0 || pageIndex >= djvu.Pages.Length)
                    {
                        Console.Error.WriteLine($"Page index out of range: {pageIndex}");
                        return;
                    }

                    BmpOptions bmpOptions = new BmpOptions
                    {
                        Source = new FileCreateSource(bmpPaths[i], false),
                        MultiPageOptions = new DjvuMultiPageOptions(pageIndex)
                    };
                    djvu.Save(bmpPaths[i], bmpOptions);
                }
            }

            // Load generated BMP images
            List<Image> bmpImages = new List<Image>();
            foreach (var bmpPath in bmpPaths)
            {
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }
                Image img = Image.Load(bmpPath);
                bmpImages.Add(img);
            }

            // Create a multi‑page image from BMPs
            using (Image multiPage = Image.Create(bmpImages.ToArray(), true))
            {
                string outputPdfPath = "output.pdf";
                string pdfDir = Path.GetDirectoryName(outputPdfPath);
                if (!string.IsNullOrWhiteSpace(pdfDir))
                {
                    Directory.CreateDirectory(pdfDir);
                }

                PdfOptions pdfOptions = new PdfOptions();
                multiPage.Save(outputPdfPath, pdfOptions);
            }

            // Dispose BMP images
            foreach (var img in bmpImages)
            {
                img.Dispose();
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
 * 1. When you need to extract specific pages from a multi‑page DjVu file and save them as high‑quality BMP images for further editing or OCR processing.
 * 2. When a legal or archival workflow requires converting selected DjVu pages into BMP format before embedding them into a PDF report.
 * 3. When an application must programmatically generate a PDF that contains only certain pages of a DjVu document, using BMP as an intermediate format for precise raster control.
 * 4. When you want to automate the creation of printable PDFs from DjVu manuals by extracting pages 4‑6 as BMPs and merging them into a single PDF file.
 * 5. When integrating Aspose.Imaging in a C# service that processes scanned documents, converting chosen DjVu pages to BMP and then packaging them into a PDF for distribution or storage.
 */
