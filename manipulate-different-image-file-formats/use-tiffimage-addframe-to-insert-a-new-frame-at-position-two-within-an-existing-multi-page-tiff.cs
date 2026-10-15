// HOW-TO: Add a New Page to a Multi‑Page TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                if (tiff.Frames.Count() < 1)
                {
                    Console.Error.WriteLine("The source TIFF has no frames.");
                    return;
                }

                TiffFrame firstFrame = tiff.Frames[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                tiff.AddFrame(newFrame);
                tiff.Save(outputPath);
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
 * 1. When you need to programmatically insert an extra page into an existing multi‑page TIFF document, such as adding a cover sheet to scanned PDFs converted to TIFF.
 * 2. When generating multi‑page TIFF reports where each page is created separately and then combined into a single file.
 * 3. When augmenting archival TIFF files with additional scanned images without rewriting the entire file.
 * 4. When building a document workflow that appends new scanned pages to a TIFF bundle as they become available.
 * 5. When creating multi‑page TIFFs for printing or faxing and you must add blank or template pages dynamically in C#.
 */
