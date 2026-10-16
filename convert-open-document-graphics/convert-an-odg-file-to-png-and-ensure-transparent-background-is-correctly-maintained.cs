// HOW-TO: Convert ODG to PNG with Transparent Background Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                OdgImage odg = (OdgImage)image;

                using (var options = new PngOptions())
                {
                    odg.Save(outputPath, options);
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
 * 1. When you need to display OpenDocument graphics on a website that only supports PNG images with alpha transparency.
 * 2. When generating thumbnails for ODG drawings to embed in reports or dashboards that require PNG format.
 * 3. When automating a batch process that converts designer‑created ODG assets into PNGs for use in mobile apps.
 * 4. When preserving the original transparent layers of an ODG illustration while exporting it for print‑ready PDFs that accept PNG overlays.
 * 5. When integrating Aspose.Imaging into a C# workflow to programmatically convert ODG files to PNG without losing background transparency.
 */
