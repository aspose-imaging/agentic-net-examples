// HOW-TO: Batch Convert SVG Files to APNG Animations in C# (Aspose.Imaging for .NET)
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

namespace SvgToApngBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input_svgs";
                string outputDirectory = "output_apngs";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all SVG files in the input directory
                string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

                foreach (string inputPath in svgFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".apng";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load SVG and save as APNG with default options
                    using (Image image = Image.Load(inputPath))
                    {
                        var apngOptions = new ApngOptions();
                        image.Save(outputPath, apngOptions);
                    }
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
 * 1. When you need to generate animated PNGs from a collection of vector SVG icons for a web UI without manually converting each file.
 * 2. When an automated build pipeline must transform design assets stored as SVGs into APNGs for use in mobile app splash screens.
 * 3. When a reporting tool requires batch conversion of SVG charts into animated PNGs to embed in PDF reports.
 * 4. When a game developer wants to create sprite animations by converting multiple SVG frames into APNG files with default timing.
 * 5. When a content management system needs to process uploaded SVG illustrations and store them as APNGs for faster client-side rendering.
 */
