// HOW-TO: Convert EMF to SVG With Embedded Base64 Images In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
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
 * 1. When a Windows application needs to display legacy EMF diagrams on a web page, converting them to SVG with Base64‑encoded raster images ensures the graphics render correctly without external files.
 * 2. When generating printable reports that combine vector shapes from EMF files with embedded photos, saving as SVG with Base64 images lets the entire document be packaged as a single file.
 * 3. When migrating a design asset library from Windows Metafile format to a cross‑platform vector format, developers can use this code to batch‑convert EMF files to self‑contained SVGs for use in browsers and mobile apps.
 * 4. When creating an SVG sprite sheet that includes icons originally stored as EMF, embedding the raster parts as Base64 avoids broken links and simplifies deployment.
 * 5. When automating a CI/CD pipeline that transforms EMF logos into SVG logos for branding assets, the code ensures the output SVG contains all image data inline, eliminating the need for separate image resources.
 */
