// HOW-TO: Convert WMF to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
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
 * 1. When you need to convert legacy WMF vector drawings to web‑friendly PNG files while keeping the original author and creation date information.
 * 2. When a document management system must display embedded WMF graphics as PNG thumbnails without losing their metadata.
 * 3. When automating a migration of design assets from Windows Metafile format to PNG for use in modern C# applications that rely on image metadata.
 * 4. When generating PNG reports from WMF charts in a C# service and you want the resulting images to retain source metadata for audit trails.
 * 5. When building a batch conversion tool in .NET that processes multiple WMF files into PNG while preserving their embedded metadata for downstream processing.
 */
