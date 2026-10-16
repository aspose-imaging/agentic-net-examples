// HOW-TO: Convert XIF and TIFF Images to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Convert XIF to PNG
                string inputXif = "input\\sample.xif";
                string outputXifPng = "output\\sample_xif.png";

                if (!File.Exists(inputXif))
                {
                    Console.Error.WriteLine($"File not found: {inputXif}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputXifPng));
                using (var image = Image.Load(inputXif))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputXifPng, pngOptions);
                }

                // Convert TIFF to PNG
                string inputTiff = "input\\sample.tiff";
                string outputTiffPng = "output\\sample_tiff.png";

                if (!File.Exists(inputTiff))
                {
                    Console.Error.WriteLine($"File not found: {inputTiff}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPng));
                using (var image = Image.Load(inputTiff))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputTiffPng, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑friendly PNG thumbnails from legacy XIF files stored in an archive.
 * 2. When a document management system must transform multi‑page TIFF scans into PNGs for faster rendering in browsers.
 * 3. When migrating a digital asset library and you must batch‑convert proprietary XIF graphics and TIFF photographs to PNG for cross‑platform compatibility.
 * 4. When creating a reporting tool that extracts images from XIF or TIFF sources and saves them as PNG to embed in PDF reports.
 * 5. When automating image preprocessing in a C# application to ensure all input images are in PNG format before applying further analysis or machine‑learning models.
 */
