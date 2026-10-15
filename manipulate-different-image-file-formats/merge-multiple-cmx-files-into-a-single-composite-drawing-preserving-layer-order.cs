// HOW-TO: Merge Multiple CMX Files into a Single PNG Preserving Layer Order in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "input1.cmx",
                "input2.cmx",
                "input3.cmx"
            };
            string outputPath = "output\\merged.png";

            // Verify input files exist
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Determine canvas size (maximum width and height among CMX files)
            int maxWidth = 0;
            int maxHeight = 0;
            foreach (string inputPath in inputPaths)
            {
                using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
                {
                    if (cmx.Width > maxWidth) maxWidth = cmx.Width;
                    if (cmx.Height > maxHeight) maxHeight = cmx.Height;
                }
            }

            // Create PNG canvas bound to output file
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, maxWidth, maxHeight))
            {
                // Merge each CMX onto the canvas preserving order
                foreach (string inputPath in inputPaths)
                {
                    using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
                    {
                        // Render CMX to a temporary PNG in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            cmx.Save(ms, new PngOptions());
                            ms.Position = 0;
                            using (RasterImage rasterCmx = (RasterImage)Image.Load(ms))
                            {
                                Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, 0, rasterCmx.Width, rasterCmx.Height);
                                canvas.SaveArgb32Pixels(bounds, rasterCmx.LoadArgb32Pixels(rasterCmx.Bounds));
                            }
                        }
                    }
                }

                // Save the bound canvas
                canvas.Save();
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
 * 1. When you need to combine several CMX vector drawings from a CAD workflow into one raster PNG for reporting or web preview while keeping the original layer stacking.
 * 2. When an automated build process must generate a composite image from multiple CMX source files to create a single thumbnail for a document management system.
 * 3. When a GIS application exports separate CMX map layers and you want to merge them into one PNG map image without losing the order of geographic features.
 * 4. When a printing service receives individual CMX pages and must stitch them together into a single PNG proof file that reflects the correct page sequence.
 * 5. When a legacy engineering tool outputs component drawings as CMX files and you need to programmatically merge them into a single PNG for inclusion in a PDF technical manual.
 */
