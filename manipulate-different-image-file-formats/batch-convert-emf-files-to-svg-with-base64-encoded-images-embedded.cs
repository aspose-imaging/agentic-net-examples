// HOW-TO: Batch Convert EMF to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\EmfInput";
            string outputDirectory = @"C:\SvgOutput";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf", SearchOption.AllDirectories);

            foreach (string inputPath in emfFiles)
            {
                // Check if the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output path with .svg extension
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Set SVG options (default behavior embeds raster images as Base64)
                    SvgOptions svgOptions = new SvgOptions();

                    // Save as SVG
                    emfImage.Save(outputPath, svgOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to migrate a library of Windows Metafile (EMF) graphics to scalable SVG files for web display while preserving embedded raster content.
 * 2. When an application must generate SVG assets from EMF diagrams in bulk and ensure the raster parts are self‑contained using Base64 encoding.
 * 3. When a reporting tool exports charts as EMF and you want to convert them to SVG for inclusion in HTML emails without external image files.
 * 4. When a CI/CD pipeline processes design assets, converting all EMF files in a folder to SVG to streamline vector asset management.
 * 5. When a legacy CAD system outputs EMF drawings and you need an automated C# script to produce SVG files that embed images for cross‑platform viewing.
 */
