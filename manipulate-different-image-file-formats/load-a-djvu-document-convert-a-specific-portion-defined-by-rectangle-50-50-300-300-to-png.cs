// HOW-TO: Extract a Rectangular Region from DjVu and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\portion.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.MultiPageOptions = new DjvuMultiPageOptions(0, new Aspose.Imaging.Rectangle(50, 50, 300, 300));
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG thumbnail of a specific area of a scanned DjVu file for display in a web application.
 * 2. When extracting a diagram or illustration from a multi‑page DjVu document to embed in a PDF report.
 * 3. When creating preview images of selected sections of large DjVu archives for a document management system.
 * 4. When converting a portion of a DjVu map to PNG for use in a GIS or mapping application.
 * 5. When producing a high‑resolution PNG snippet of a DjVu e‑book chapter for offline viewing on mobile devices.
 */
