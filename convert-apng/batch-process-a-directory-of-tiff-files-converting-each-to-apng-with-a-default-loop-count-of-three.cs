// HOW-TO: Batch Convert TIFF Files to Animated PNG with Loop Count in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".apng");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(file))
                {
                    var apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        NumPlays = 3
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(raster);
                        apng.Save();
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
 * 1. When you need to generate animated PNG previews from a collection of multi‑page TIFF scans for web galleries.
 * 2. When you want to automate the conversion of medical imaging TIFF files into looping APNGs for interactive reports.
 * 3. When a batch job must transform archived TIFF assets into lightweight animated PNGs with a predefined three‑play loop for mobile apps.
 * 4. When you are building a server‑side service that ingests TIFF diagrams and outputs APNG animations that repeat three times for presentations.
 * 5. When you need to replace TIFF‑based slide decks with APNG animations that automatically loop a set number of times in a .NET application.
 */
