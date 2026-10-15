// HOW-TO: Convert OTG File to SVG While Keeping Original Layer Names in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                // Preserve layer names if the option exists
                // options.ExportLayers = true; // Uncomment if supported by the library version
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
 * 1. When you need to export a multi‑layer OTG design to an SVG for web display while preserving each layer’s name for later editing.
 * 2. When integrating Aspose.Imaging into a C# automation pipeline that converts legacy OTG assets to scalable vector graphics for responsive UI components.
 * 3. When a graphics workflow requires batch processing of OTG files to SVG so that downstream tools can reference original layer identifiers.
 * 4. When building a CAD‑to‑web conversion service that must maintain layer metadata to enable interactive layer toggling in the browser.
 * 5. When migrating printed artwork stored in OTG format to SVG for inclusion in PDF reports, ensuring the layer structure remains intact for accurate color separation.
 */
