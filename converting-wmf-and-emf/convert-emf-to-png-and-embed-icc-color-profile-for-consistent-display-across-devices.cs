// HOW-TO: Convert EMF File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
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
                    options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a Windows desktop application needs to display vector EMF icons as raster PNGs for high‑DPI screens.
 * 2. When generating PDF or HTML reports that require embedded PNG images converted from legacy EMF diagrams.
 * 3. When a web service must accept user‑uploaded EMF files and return PNG thumbnails for preview in a browser.
 * 4. When migrating a legacy document management system and you need to batch‑convert stored EMF graphics to PNG for cross‑platform compatibility.
 * 5. When creating an automated build pipeline that converts EMF assets to PNG to be bundled with a mobile app’s resources.
 */
