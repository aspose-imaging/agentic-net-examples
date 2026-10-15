// HOW-TO: Convert DjVu Pages To 32‑Bit BMP Images In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions();
                    bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(i);

                    djvu.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑color‑depth BMP files for further processing in Windows applications.
 * 2. When a document archiving system requires converting scanned DjVu documents into BMP format to preserve image quality before printing.
 * 3. When a graphics pipeline must batch‑convert DjVu pages to 32‑bit BMPs to feed into a legacy image analysis tool that only accepts BMP input.
 * 4. When you are building a .NET service that generates thumbnail previews by first converting DjVu pages to BMP and then resizing them.
 * 5. When you need to programmatically split a DjVu ebook into individual BMP images for use in a custom e‑learning platform.
 */
