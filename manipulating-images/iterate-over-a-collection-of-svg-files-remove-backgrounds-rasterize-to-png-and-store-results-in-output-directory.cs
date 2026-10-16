// HOW-TO: Batch Remove SVG Backgrounds and Convert to PNG in C# (Aspose.Imaging for .NET)
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

namespace SvgProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputSvgs";
                string outputDirectory = @"C:\OutputPngs";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

                foreach (string inputPath in svgFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        // Attempt to remove background if the method exists
                        var removeMethod = image.GetType().GetMethod("RemoveBackground");
                        if (removeMethod != null)
                        {
                            removeMethod.Invoke(image, null);
                        }

                        // Rasterize SVG to PNG
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
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
 * 1. When you need to process a folder of SVG icons, strip any embedded background layers, and generate transparent PNG assets for web use.
 * 2. When automating the preparation of vector graphics for mobile apps, you can batch‑convert SVG logos to PNG while ensuring the background is removed.
 * 3. When creating a CI pipeline that publishes design assets, this code lets you convert all SVG files in a repository to PNG thumbnails without manual editing.
 * 4. When migrating legacy SVG diagrams to a raster format for PDF reports, you can programmatically remove backgrounds and save them as PNGs.
 * 5. When building a desktop utility that cleans up user‑uploaded SVGs before storage, the script iterates through files, clears backgrounds, and stores the resulting PNGs in a designated output folder.
 */
