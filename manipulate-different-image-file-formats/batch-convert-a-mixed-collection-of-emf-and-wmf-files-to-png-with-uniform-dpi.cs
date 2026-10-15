// HOW-TO: Batch Convert EMF And WMF Files To PNG With 300 DPI In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => string.Equals(Path.GetExtension(f), ".emf", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(Path.GetExtension(f), ".wmf", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (PngOptions options = new PngOptions())
                {
                    options.ResolutionSettings = new ResolutionSetting(300, 300);
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate high‑resolution PNG thumbnails from a legacy collection of vector EMF and WMF graphics for a web gallery.
 * 2. When an automated build process must convert all Windows Metafile assets in a project folder to PNG with a consistent 300 dpi for printing purposes.
 * 3. When a migration script has to replace EMF/WMF icons with PNG equivalents while preserving visual quality across different screen densities.
 * 4. When a reporting tool requires rasterized PNG images of vector diagrams at a fixed DPI to embed them in PDF reports.
 * 5. When a batch job processes user‑uploaded EMF or WMF files and stores them as PNGs with uniform resolution for downstream image‑processing pipelines.
 */
