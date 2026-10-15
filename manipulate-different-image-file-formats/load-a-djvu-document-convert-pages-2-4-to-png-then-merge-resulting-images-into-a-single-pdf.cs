// HOW-TO: Convert DjVu Pages 2 To 4 To PNG And Merge Into PDF In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Convert pages 2-4 to PNG
            List<string> pngPaths = new List<string>();
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int pageIndex = 1; pageIndex <= 3; pageIndex++) // pages 2,3,4 (0‑based)
                {
                    string pngPath = $"page{pageIndex + 1}.png";
                    pngPaths.Add(pngPath);

                    string pngDir = Path.GetDirectoryName(pngPath);
                    Directory.CreateDirectory(pngDir ?? ".");

                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(pageIndex)
                    };
                    djvu.Save(pngPath, pngOptions);
                }
            }

            // Verify PNG files exist
            foreach (string pngPath in pngPaths)
            {
                if (!File.Exists(pngPath))
                {
                    Console.Error.WriteLine($"File not found: {pngPath}");
                    return;
                }
            }

            // Load PNG images
            List<Image> images = new List<Image>();
            foreach (string pngPath in pngPaths)
            {
                Image img = Image.Load(pngPath);
                images.Add(img);
            }

            // Prepare PDF output
            string pdfPath = "merged.pdf";
            string pdfDir = Path.GetDirectoryName(pdfPath);
            Directory.CreateDirectory(pdfDir ?? ".");

            PdfOptions pdfOptions = new PdfOptions();

            using (Image pdf = Image.Create(images.ToArray(), true))
            {
                pdf.Save(pdfPath, pdfOptions);
            }

            // Dispose loaded images
            foreach (var img in images)
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
 * 1. When you need to extract specific pages from a DjVu document and create high‑quality PNG images for web preview.
 * 2. When you must combine selected DjVu pages into a single PDF for easier distribution or printing.
 * 3. When an archival workflow requires converting multi‑page DjVu scans to individual PNG files before further processing.
 * 4. When a reporting tool needs to embed only certain DjVu pages as images and then generate a consolidated PDF report.
 * 5. When a document management system must programmatically transform DjVu pages into PDF while preserving page order and image fidelity.
 */
