// HOW-TO: Convert JPEG to Grayscale Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\grayscale.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Grayscale();

                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate a grayscale version of a user‑uploaded JPEG for a photo‑editing web app using C# and Aspose.Imaging.
 * 2. When preparing JPEG images for printing in black‑and‑white to reduce ink usage in a desktop publishing workflow.
 * 3. When creating thumbnails for a gallery where all images must be displayed in grayscale to match a design theme.
 * 4. When converting color JPEG scans of documents into grayscale for OCR preprocessing in a .NET service.
 * 5. When archiving legacy color JPEG photos as smaller grayscale files to save storage space while preserving visual content.
 */
