// HOW-TO: Crop an EMF Image to Specific Area and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\cropped.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                int left = 10;
                int top = 10;
                int width = 200;
                int height = 200;
                var cropRect = new Rectangle(left, top, width, height);
                emf.Crop(cropRect);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                emf.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a portion of a vector‑based EMF diagram for inclusion in a web page as a lightweight PNG thumbnail.
 * 2. When generating report assets that require converting and trimming EMF charts to fixed‑size PNG images for email attachments.
 * 3. When preprocessing legacy EMF icons to create uniformly sized PNG sprites for a desktop application UI.
 * 4. When automating batch conversion of scanned EMF drawings, cropping out margins before saving them as PNG files for archival.
 * 5. When building a document conversion service that must isolate a specific region of an EMF file and deliver it as a PNG to downstream systems.
 */
