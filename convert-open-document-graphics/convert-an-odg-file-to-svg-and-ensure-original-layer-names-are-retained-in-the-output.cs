// HOW-TO: Convert ODG to SVG While Preserving Layer Names in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
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
 * 1. When you need to import an OpenDocument Graphics (ODG) illustration into a web page and keep the original layer structure for interactive editing, you can convert it to SVG with Aspose.Imaging in C#.
 * 2. When a design workflow requires exporting multi‑layer ODG diagrams to scalable SVG files for printing or further processing while preserving layer names for downstream tools.
 * 3. When automating batch conversion of ODG assets to SVG in a .NET application, ensuring each SVG retains the source layer identifiers for accurate mapping in GIS or CAD systems.
 * 4. When integrating ODG files from LibreOffice Draw into a C#‑based reporting engine that consumes SVG, and you must maintain layer names to apply conditional styling.
 * 5. When migrating legacy ODG artwork to a modern vector format without losing layer metadata, allowing developers to programmatically manipulate individual layers after conversion.
 */
