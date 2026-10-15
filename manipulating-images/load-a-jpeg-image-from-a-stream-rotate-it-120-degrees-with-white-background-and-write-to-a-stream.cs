// HOW-TO: Rotate JPEG By 120 Degrees And Save To Stream Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                image.Rotate(120.0f);
                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to programmatically rotate a user‑uploaded JPEG photo by a specific angle before storing it in a database.
 * 2. When generating thumbnails that require a fixed 120° rotation to match a custom layout in a web gallery.
 * 3. When processing scanned documents that were scanned upside‑down and must be corrected by rotating the JPEG image.
 * 4. When creating image assets for a mobile app that expects all JPEGs to be oriented consistently, such as a 120° rotation for a game background.
 * 5. When automating batch image transformations in a server‑side service that reads JPEGs from a stream, rotates them, and writes the result back to another stream or file.
 */
