// HOW-TO: Convert Each DjVu Page To Separate PNG Files In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
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
 * 1. When you need to extract individual pages from a multi‑page DjVu document and save them as high‑quality PNG images for web preview or further processing.
 * 2. When a digital archive requires converting scanned DjVu files into PNG thumbnails to display in a C#‑based document management system.
 * 3. When an e‑learning platform must break down DjVu lecture notes into separate PNG slides for integration into PowerPoint or HTML presentations.
 * 4. When a batch workflow automates the transformation of DjVu manuals into PNG assets for inclusion in mobile apps that only support PNG.
 * 5. When a content‑migration script needs to programmatically read DjVu files and generate PNG pages to preserve visual fidelity while moving to a new storage format.
 */
