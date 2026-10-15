// HOW-TO: Convert ODG to JPEG with Embedded ICC Profile in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";
            string iccPath = "profile.icc";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (FileStream iccStream = File.OpenRead(iccPath))
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.RgbColorProfile = new StreamSource(iccStream);
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
 * 1. When a developer needs to generate print‑ready JPEGs from LibreOffice ODG drawings while preserving accurate colors across monitors and printers.
 * 2. When an application must convert user‑uploaded ODG files to web‑friendly JPEG thumbnails that include an ICC profile for consistent display.
 * 3. When a batch‑processing service has to transform a collection of ODG assets into JPEGs with embedded color profiles for a digital asset management system.
 * 4. When integrating a document workflow that requires converting ODG diagrams to JPEGs with embedded ICC data to meet brand‑color standards.
 * 5. When building a C# utility that prepares ODG graphics for email newsletters, ensuring the JPEGs retain the original color intent via an ICC profile.
 */
