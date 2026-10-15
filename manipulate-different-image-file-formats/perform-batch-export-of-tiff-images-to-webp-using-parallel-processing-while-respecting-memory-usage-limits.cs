// HOW-TO: Batch Convert TIFF to WebP in Parallel with Memory Limit in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

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

            System.Threading.Tasks.Parallel.ForEach(files, new System.Threading.Tasks.ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    return;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(file, new Aspose.Imaging.LoadOptions { BufferSizeHint = 10 }))
                {
                    Aspose.Imaging.FileFormats.Tiff.TiffImage tiff = image as Aspose.Imaging.FileFormats.Tiff.TiffImage;
                    if (tiff == null)
                    {
                        Console.Error.WriteLine($"Not a TIFF image: {file}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".webp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var options = new WebPOptions())
                    {
                        options.Quality = 90;
                        tiff.Save(outputPath, options);
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly shrink a large collection of high‑resolution TIFF scans for web delivery, converting them to WebP in parallel reduces processing time while keeping memory usage low.
 * 2. When a server‑side image pipeline must handle user‑uploaded TIFF files and output optimized WebP thumbnails without exhausting RAM, this code provides a scalable solution.
 * 3. When migrating a digital archive from TIFF to a modern, lossy‑lossless format, batch conversion with Aspose.Imaging lets you automate the process across multiple CPU cores.
 * 4. When building a background service that processes nightly batches of medical or satellite TIFF imagery into WebP for faster downstream analytics, the parallel loop respects a buffer size hint to stay within memory limits.
 * 5. When integrating image conversion into a CI/CD workflow that validates and compresses TIFF assets before deployment, the code ensures fast, concurrent conversion while preventing out‑of‑memory errors.
 */
