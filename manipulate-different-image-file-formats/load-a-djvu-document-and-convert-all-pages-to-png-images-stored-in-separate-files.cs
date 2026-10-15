// HOW-TO: Convert Each DjVu Page to Separate PNG Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    var options = new PngOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(i)
                    };
                    djvu.Save(outputPath, options);
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
 * 1. When you need to extract every page of a DjVu document as high‑quality PNG images for web preview or archival purposes.
 * 2. When an application must batch‑process scanned books in DjVu format and generate individual PNG files for OCR pipelines.
 * 3. When a digital publishing workflow requires converting multi‑page DjVu manuals into separate PNG assets for inclusion in e‑learning modules.
 * 4. When a document management system stores contracts as DjVu and you need to create thumbnail PNGs for each page to display in a UI.
 * 5. When a migration tool moves legacy DjVu archives to a PNG‑based image repository, preserving each page as an independent file.
 */
