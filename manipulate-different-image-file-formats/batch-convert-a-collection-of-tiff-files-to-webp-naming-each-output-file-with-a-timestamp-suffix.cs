// HOW-TO: Batch Convert TIFF Files to WebP with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string ext = Path.GetExtension(inputPath);
                if (!string.Equals(ext, ".tif", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(ext, ".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{timestamp}.webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        image.Save(outputPath, options);
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
 * 1. When you need to shrink a large collection of scanned TIFF documents for faster web delivery, you can batch convert them to WebP and add a timestamp to avoid filename collisions.
 * 2. When an automated nightly job must archive newly generated TIFF images as optimized WebP files while preserving the original creation time in the filename.
 * 3. When a digital asset management system requires converting user‑uploaded TIFF photos to a modern web‑friendly format and tracking when each conversion occurred.
 * 4. When a reporting tool generates TIFF charts that must be embedded in web pages, you can convert them to WebP on the fly and include a timestamp to ensure cache busting.
 * 5. When migrating legacy medical imaging archives from TIFF to WebP for storage efficiency, the code can process all files in a folder and name each output with a unique timestamp.
 */
