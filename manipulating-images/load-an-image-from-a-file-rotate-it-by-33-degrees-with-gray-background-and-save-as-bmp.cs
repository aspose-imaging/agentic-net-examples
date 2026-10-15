// HOW-TO: Rotate JPEG By 33 Degrees With Gray Background And Save As BMP In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.jpg";
        string outputPath = "Output\\rotated.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Rotate(33.0f, true, Aspose.Imaging.Color.Gray);
                BmpOptions options = new BmpOptions();
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
 * 1. When you need to generate a BMP thumbnail of a photo rotated by a specific angle while preserving a uniform gray fill for the empty corners.
 * 2. When an application must preprocess scanned JPEG documents by rotating them 33 degrees and converting them to BMP for legacy Windows printing.
 * 3. When a game asset pipeline requires rotating texture images at arbitrary angles and saving them as BMP files with a consistent background color.
 * 4. When automating batch image preparation for OCR, you rotate misaligned JPEGs and output BMPs that OCR engines handle more reliably.
 * 5. When integrating Aspose.Imaging in a C# service that adjusts image orientation and stores the result in BMP format for downstream processing.
 */
