// HOW-TO: Rotate Each Page of a DjVu File and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDirectory = "Output";
        Directory.CreateDirectory(outputDirectory);

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions exportOptions = new PngOptions();
                        exportOptions.MultiPageOptions = new DjvuMultiPageOptions(i);
                        djvu.Save(ms, exportOptions);
                        ms.Position = 0;

                        using (RasterImage pageImage = (RasterImage)Image.Load(ms))
                        {
                            pageImage.Rotate(90f, true, Color.White);
                            string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            pageImage.Save(outputPath);
                        }
                    }
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
 * 1. When you need to display scanned documents on a web page that only supports PNG, you can rotate each DjVu page and convert it to PNG.
 * 2. When preparing archival images for printing, you may have to reorient DjVu pages before exporting them as high‑quality PNG files.
 * 3. When building a document‑viewer app that requires portrait orientation, you can programmatically rotate DjVu pages and save them as PNG thumbnails.
 * 4. When integrating legacy DjVu archives into a modern C# workflow, you can convert each page to PNG after correcting its orientation.
 * 5. When automating batch processing of multi‑page DjVu files, you can rotate and export each page to PNG for downstream image analysis.
 */
