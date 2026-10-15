// HOW-TO: Extract All Pages from DjVu and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/document.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                Console.WriteLine($"Number of pages: {djvuImage.PageCount}");

                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions();
                    options.MultiPageOptions = new DjvuMultiPageOptions(i);

                    djvuImage.Save(outputPath, options);
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
 * 1. When you need to programmatically split a multi‑page DjVu document into separate PNG images for web preview or archival.
 * 2. When an application must display the total number of pages in a DjVu file before converting each page to a raster format.
 * 3. When you want to automate batch processing of DjVu files and generate high‑resolution PNGs for each page in a .NET environment.
 * 4. When integrating Aspose.Imaging into a document‑management system that requires conversion of scanned DjVu files to PNG for downstream OCR or editing.
 * 5. When building a reporting tool that extracts individual pages from a DjVu manual and saves them as PNG thumbnails for quick navigation.
 */
