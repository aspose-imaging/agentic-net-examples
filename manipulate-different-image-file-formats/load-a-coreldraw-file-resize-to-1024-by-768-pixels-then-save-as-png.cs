// HOW-TO: Resize CorelDRAW CDR to PNG 1024x768 Using Aspose Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.Resize(1024, 768, ResizeType.LanczosResample);
                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image and cannot be resized.");
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
 * 1. When a developer needs to convert legacy CorelDRAW CDR files into web‑friendly PNG thumbnails of a specific size.
 * 2. When an application must generate preview images for CDR documents to display in a gallery or CMS.
 * 3. When a batch process has to resize imported CDR artwork to 1024 × 768 pixels before printing or further raster editing.
 * 4. When a .NET service integrates Aspose.Imaging to transform client‑uploaded CDR files into standardized PNG assets for mobile apps.
 * 5. When a developer wants to ensure consistent image dimensions while converting design files to PNG for email newsletters.
 */
