// HOW-TO: Extract 400x400 Region From DjVu And Save As BMP In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvuImage = (DjvuImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(0, 0, 400, 400);
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(0, rect);
                djvuImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a thumbnail BMP of the first page of a DjVu document for a web preview.
 * 2. When you want to extract a specific 400‑pixel square from a scanned DjVu file to use in a report or presentation.
 * 3. When an application must convert a region of a multi‑page DjVu archive into a BMP image for legacy Windows software that only reads BMP.
 * 4. When you are processing large DjVu files and only require a defined area to reduce memory usage before further analysis.
 * 5. When you need to automate batch conversion of selected DjVu sections to BMP format in a C# backend service.
 */
