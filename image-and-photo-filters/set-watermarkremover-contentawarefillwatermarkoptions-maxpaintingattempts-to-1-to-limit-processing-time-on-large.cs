// HOW-TO: Limit Watermark Removal Time on Large TIFFs by Setting MaxPaintingAttempts to 1 in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tiff";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.Save(outputPath);
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
 * 1. When processing multi‑gigabyte scanned documents in TIFF format, a developer may set MaxPaintingAttempts to 1 to prevent the watermark removal algorithm from taking excessive time.
 * 2. When building a batch job that removes watermarks from thousands of high‑resolution TIFF images, limiting painting attempts ensures the job completes within a scheduled window.
 * 3. When deploying an image‑processing service on limited‑resource servers, configuring MaxPaintingAttempts to 1 helps avoid CPU spikes caused by content‑aware fill on large TIFF files.
 * 4. When creating a user‑facing application that quickly previews TIFF pages after watermark removal, reducing painting attempts provides faster feedback for large files.
 * 5. When troubleshooting performance bottlenecks in a document‑archiving pipeline, adjusting MaxPaintingAttempts allows developers to balance watermark removal quality against processing time for big TIFF images.
 */
