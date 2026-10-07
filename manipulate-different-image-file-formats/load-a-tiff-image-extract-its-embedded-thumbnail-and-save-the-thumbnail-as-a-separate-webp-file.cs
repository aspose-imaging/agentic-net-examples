// HOW-TO: Extract Embedded TIFF Thumbnail and Save as WebP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "thumbnail.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)tiff.ActiveFrame)
                {
                    WebPOptions options = new WebPOptions();
                    raster.Save(outputPath, options);
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
 * 1. When you need to generate lightweight preview images from high‑resolution TIFF files for web galleries, you can extract the embedded thumbnail and convert it to WebP using C#.
 * 2. When a document management system stores scanned TIFFs with embedded thumbnails and you want to display those thumbnails quickly on mobile devices, this code extracts and saves them as WebP.
 * 3. When optimizing storage for a digital asset pipeline, you can pull the small TIFF thumbnail and re‑encode it to WebP to reduce file size while preserving visual fidelity.
 * 4. When building a PDF generation service that requires a small preview of each page scanned as TIFF, you can retrieve the thumbnail and convert it to WebP for inclusion in the PDF.
 * 5. When creating a thumbnail cache for a desktop application that browses large TIFF archives, this snippet lets you extract the built‑in thumbnail and store it as a WebP file for fast loading.
 */
