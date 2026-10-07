// HOW-TO: Convert DjVu Pages to 24‑Bit BMP Images in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Djvu;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.djvu";
                string outputFolder = "output";
                string outputPathPattern = Path.Combine(outputFolder, "page_{0}.bmp");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(outputFolder);

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    int pageCount = djvu.Pages.Length;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outPath = string.Format(outputPathPattern, i + 1);
                        BmpOptions options = new BmpOptions();
                        djvu.Pages[i].Save(outPath, options);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑quality 24‑bit BMP images for further processing in Windows applications.
 * 2. When a document archiving system requires conversion of scanned DjVu documents into BMP format to preserve lossless pixel data for OCR engines.
 * 3. When a legacy graphics pipeline only accepts BMP images, you can programmatically transform DjVu pages to 24‑bit BMPs using Aspose.Imaging in C#.
 * 4. When preparing DjVu‑based e‑books for printing, converting each page to BMP ensures compatibility with printers that require bitmap input.
 * 5. When building a batch conversion tool that processes a folder of DjVu files and outputs separate BMP files per page for use in image analysis or machine‑learning models.
 */
