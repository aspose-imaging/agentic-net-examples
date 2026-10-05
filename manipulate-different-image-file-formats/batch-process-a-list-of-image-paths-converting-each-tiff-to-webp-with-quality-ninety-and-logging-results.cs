// HOW-TO: Batch Convert TIFF Images to WebP with Quality 90 in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                {
                    continue;
                }

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".webp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(file))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        options.Quality = 90;
                        image.Save(outputPath, options);
                    }
                }

                Console.WriteLine($"Converted: {file} -> {outputPath}");
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
 * 1. When you need to automate the conversion of a large collection of TIFF files to smaller WebP files for faster web delivery while preserving visual quality.
 * 2. When you want to integrate Aspose.Imaging into a C# application to process images in a folder, convert them to WebP with a specific quality setting, and store the results in an output directory.
 * 3. When you have to generate WebP thumbnails from high‑resolution TIFF scans for a digital archive and need to log each conversion for audit purposes.
 * 4. When you are building a server‑side image pipeline that must skip non‑TIFF files, convert only the supported formats, and handle missing files gracefully.
 * 5. When you require a simple console utility that creates missing input/output folders, iterates through files, and reports success or errors during batch image format conversion.
 */
