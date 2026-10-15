// HOW-TO: Batch Convert WMF to SVG with Red Fill Color in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                        rasterOptions.BackgroundColor = Color.Red;
                        rasterOptions.PageWidth = image.Width;
                        rasterOptions.PageHeight = image.Height;
                        svgOptions.VectorRasterizationOptions = rasterOptions;
                        image.Save(outputPath, svgOptions);
                    }
                }
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
 * 1. When you need to automatically transform a collection of legacy WMF diagrams into scalable SVG files for web display while applying a consistent background color.
 * 2. When a reporting system must generate SVG charts from WMF assets and ensure all shapes share the same fill color for brand consistency.
 * 3. When a batch image‑processing pipeline has to convert multiple WMF icons to SVG format and apply a uniform color to simplify downstream styling.
 * 4. When migrating a desktop application’s vector assets from WMF to SVG and you want to enforce a single background hue across all converted files.
 * 5. When preparing WMF‑based technical drawings for inclusion in documentation and you need them in SVG with a predefined fill color without manual editing.
 */
