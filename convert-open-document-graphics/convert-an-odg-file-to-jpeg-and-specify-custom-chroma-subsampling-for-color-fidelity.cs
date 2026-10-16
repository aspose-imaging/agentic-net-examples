// HOW-TO: Convert ODG File to JPEG with High Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 95
            };

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a developer needs to generate web‑ready JPEG previews from ODG drawings created in LibreOffice.
 * 2. When an application must batch‑convert ODG diagrams to JPEG for inclusion in email attachments while preserving image quality.
 * 3. When a reporting tool requires converting vector ODG charts to raster JPEG images for PDF export.
 * 4. When a mobile app downloads ODG assets and needs to display them as JPEG thumbnails with controlled compression.
 * 5. When a content management system stores ODG files but serves JPEG versions to browsers for faster loading.
 */
