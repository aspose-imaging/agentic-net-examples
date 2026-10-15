// HOW-TO: Convert DjVu Document to 24‑Bit BMP Images in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.MultiPageOptions = new DjvuMultiPageOptions();

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract high‑quality bitmap pages from a multi‑page DjVu file for printing or further image analysis in a .NET application.
 * 2. When a legacy system only accepts 24‑bit BMP files and you must convert incoming DjVu documents without losing page information.
 * 3. When preparing DjVu‑based e‑books for Windows desktop viewers that require BMP format with a specific bits‑per‑pixel setting.
 * 4. When automating a batch process that converts scanned DjVu archives into BMP images for OCR engines that work best with 24‑bit color depth.
 * 5. When integrating Aspose.Imaging into a C# service that receives DjVu uploads and needs to store each page as a BMP file for downstream graphics pipelines.
 */
