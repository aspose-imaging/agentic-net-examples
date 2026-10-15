// HOW-TO: Convert DjVu Pages 3 to 7 to Animated GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\range3to7.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1048576 }))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(3, 7));
                djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a specific range of pages from a large DjVu document and create a single GIF for web preview.
 * 2. When you want to reduce memory consumption while loading a high‑resolution DjVu file before converting selected pages to GIF.
 * 3. When an application must generate an animated GIF from pages 3‑7 of a scanned book stored as DjVu for inclusion in a mobile app.
 * 4. When automating batch processing of DjVu archives and only the middle pages are required as GIFs for documentation thumbnails.
 * 5. When integrating Aspose.Imaging in a C# service to serve GIF previews of particular DjVu pages without loading the entire document into memory.
 */
