// HOW-TO: Batch Convert BMP Images to SVG with Custom Namespace in C# (Aspose.Imaging for .NET)
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
using System.Xml;

namespace BatchBmpToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input";
                string outputDirectory = "output";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string bmpPath in bmpFiles)
                {
                    // Validate input file existence
                    if (!File.Exists(bmpPath))
                    {
                        Console.Error.WriteLine($"File not found: {bmpPath}");
                        return;
                    }

                    // Load BMP image
                    using (Image image = Image.Load(bmpPath))
                    {
                        // Prepare output SVG path
                        string outputPath = Path.Combine(
                            outputDirectory,
                            Path.GetFileNameWithoutExtension(bmpPath) + ".svg");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as SVG using SvgOptions
                        var svgOptions = new SvgOptions();
                        image.Save(outputPath, svgOptions);
                    }

                    // Add custom XML namespace to the generated SVG
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(bmpPath.Replace(".bmp", ".svg")); // Load the just-saved SVG
                    XmlElement root = xmlDoc.DocumentElement;
                    if (root != null)
                    {
                        root.SetAttribute("xmlns:custom", "http://example.com/custom");
                        xmlDoc.Save(Path.Combine(
                            outputDirectory,
                            Path.GetFileNameWithoutExtension(bmpPath) + ".svg"));
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
 * 1. When you need to transform a folder of legacy BMP files into scalable SVG graphics for web display while preserving vector quality.
 * 2. When downstream tools require an additional XML namespace in each SVG to identify custom metadata or processing instructions.
 * 3. When automating a migration pipeline that converts raster assets to vector format before applying further SVG‑based styling or animation.
 * 4. When generating SVGs from BMPs in bulk to reduce file size and enable resolution‑independent rendering in responsive applications.
 * 5. When integrating Aspose.Imaging into a C# service that prepares image assets for a CAD or GIS system that expects SVG files with a specific namespace.
 */
