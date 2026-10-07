// HOW-TO: Batch Convert TIFF to WebP in Parallel with Memory Limit in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions { BufferSizeHint = 100 * 1024 * 1024 };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    using (WebPOptions webpOptions = new WebPOptions())
                    {
                        image.Save(outputPath, webpOptions);
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
 * 1. When you need to quickly convert a large folder of high‑resolution TIFF scans to smaller WebP files for web delivery while keeping RAM usage low.
 * 2. When an automated image‑processing pipeline must handle dozens of TIFF documents simultaneously on a multi‑core server without running out of memory.
 * 3. When you are building a desktop tool that lets users drop a batch of TIFF medical images and get WebP versions for faster viewing on browsers.
 * 4. When you want to integrate parallel image conversion into a CI/CD step that prepares assets for a responsive website, ensuring each conversion respects a 100 MB buffer.
 * 5. When you have limited hardware resources and must process TIFF archives in parallel, converting them to WebP to reduce storage costs and improve load times.
 */
