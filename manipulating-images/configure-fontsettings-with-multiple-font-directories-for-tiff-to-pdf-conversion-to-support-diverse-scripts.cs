// HOW-TO: Convert TIFF to PDF with Multiple Font Folders in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] fontDirs = new string[] { "Fonts/Dir1", "Fonts/Dir2" };
            foreach (var dir in fontDirs)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            FontSettings.SetFontsFolders(fontDirs, false);

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert scanned TIFF documents that contain Asian or Cyrillic text to searchable PDF while providing custom font folders for proper glyph rendering.
 * 2. When your application must generate PDFs from multi‑page TIFFs on a server that has fonts installed in non‑standard directories.
 * 3. When you are processing TIFF images with embedded text and want to ensure the PDF output uses the correct fonts for diverse scripts without modifying the system font registry.
 * 4. When you want to automate batch conversion of TIFF files to PDF in a .NET service and need to load fonts from multiple locations to support multilingual documents.
 * 5. When you are building a document workflow that requires reliable TIFF‑to‑PDF conversion while explicitly specifying font search paths to avoid missing‑character errors.
 */
