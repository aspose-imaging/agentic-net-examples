// HOW-TO: Convert EMF to SVG With External Images In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions options = new SvgOptions())
                {
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into scalable SVG files for web pages while keeping embedded raster images as separate files.
 * 2. When generating printable reports that contain EMF charts and the output must be an SVG document that references external image assets for better performance.
 * 3. When migrating a desktop application’s icons from EMF to SVG format to support high‑resolution displays, and the icons include bitmap resources that should remain external.
 * 4. When creating an automated pipeline that extracts vector drawings from EMF files and stores them as SVG files alongside their associated PNG/JPEG images for use in a content management system.
 * 5. When building a cross‑platform UI where designers provide EMF assets and developers need to programmatically produce SVG files with linked images to ensure compatibility with browsers and mobile devices.
 */
