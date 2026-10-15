// HOW-TO: Convert DjVu Pages 1 to 3 Into Animated GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/document.djvu";
            string outputPath = "Output/animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(1, 3));
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
 * 1. When you need to embed a short animation of selected DjVu pages in a web page.
 * 2. When you want to create a preview GIF of the first few pages of a scanned book stored as DjVu.
 * 3. When you have to generate an animated thumbnail for a document management system that only supports GIF.
 * 4. When you need to extract a specific page range from a DjVu file and share it as a lightweight animation.
 * 5. When you are building a C# application that converts multi‑page DjVu documents into GIF animations for email attachments.
 */
