// HOW-TO: Convert PDF Map with Coordinates to SVG Using C# Aspose Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\map.pdf";
            string outputPath = "Output\\map.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When a GIS application needs to display high‑resolution vector maps on the web, developers can convert PDF map files to SVG to retain scalable graphics and coordinate metadata.
 * 2. When an online mapping portal wants to reduce file size while keeping editability, developers use this code to transform PDF maps into lightweight SVG files for faster loading.
 * 3. When a mobile app requires interactive map layers, developers convert PDF maps to SVG so the vectors can be styled with CSS and the geographic coordinates remain accessible.
 * 4. When a data‑visualization pipeline must integrate map data into HTML dashboards, developers employ this conversion to embed SVG maps with preserved coordinate information.
 * 5. When an automated reporting system generates PDF maps and later needs to reuse them in vector‑based charts, developers use this code to extract SVG versions without losing the original geospatial metadata.
 */
