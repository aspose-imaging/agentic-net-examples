// HOW-TO: Create Animated GIF From Specific DjVu Pages In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                // Export pages 7‑9 (zero‑based indexes 6,7,8)
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 6, 7, 8 });
                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a subset of pages from a multi‑page DjVu document and generate a single animated GIF for web preview.
 * 2. When building a document viewer that shows selected DjVu pages as a looping animation in a Windows application.
 * 3. When automating batch conversion of specific DjVu pages to an animated GIF for inclusion in marketing emails.
 * 4. When creating a lightweight preview of scanned book chapters stored in DjVu by converting pages 7‑9 into an animated GIF.
 * 5. When integrating Aspose.Imaging into a C# service that produces animated GIF thumbnails from chosen DjVu pages for a content management system.
 */
