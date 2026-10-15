// HOW-TO: Convert ODG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
                    image.Save(outputPath, options);
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
 * 1. When you need to embed OpenDocument graphics in a web page that only supports PNG, you can convert the ODG file to a PNG image with the smallest possible file size using loss‑less compression.
 * 2. When generating thumbnails for a document management system, converting ODG drawings to PNG ensures fast loading while preserving exact visual fidelity.
 * 3. When exporting design assets from LibreOffice Draw for use in a mobile app, the code produces PNG files that are optimized for bandwidth‑limited networks.
 * 4. When archiving vector‑based diagrams as raster images for backup, the maximum ZIP compression level reduces storage costs without sacrificing image quality.
 * 5. When integrating Aspose.Imaging into an automated build pipeline, the snippet converts ODG resources to PNG automatically, guaranteeing consistent compression across all generated assets.
 */
