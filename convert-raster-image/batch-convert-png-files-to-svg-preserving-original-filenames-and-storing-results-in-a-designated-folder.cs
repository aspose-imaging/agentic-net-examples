// HOW-TO: Batch Convert PNG Images to SVG Files in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace BatchPngToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "input";
                string outputFolder = "output";

                // Ensure the output folder exists
                Directory.CreateDirectory(outputFolder);

                string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);
                foreach (var pngPath in pngFiles)
                {
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(pngPath) + ".svg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var image = Image.Load(pngPath))
                    {
                        var options = new SvgOptions();
                        image.Save(outputPath, options);
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
 * 1. When you need to generate scalable vector graphics from a collection of PNG icons for a web UI, preserving each original filename.
 * 2. When automating the conversion of product photos stored as PNGs into SVGs for responsive design without manually renaming files.
 * 3. When preparing a set of raster diagrams for printing at any resolution by batch converting them to SVG using C#.
 * 4. When migrating legacy PNG assets to vector format for a mobile app and you want the process to run on a server with Aspose.Imaging.
 * 5. When creating an automated build step that transforms all PNG assets in a folder into SVGs and saves them to a designated output directory.
 */
