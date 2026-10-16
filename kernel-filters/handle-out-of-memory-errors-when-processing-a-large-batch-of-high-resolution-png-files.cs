// HOW-TO: How To Process Large PNG Batch Without Out Of Memory In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 1024 * 1024 };
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
                {
                    using (var options = new PngOptions())
                    {
                        options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a developer needs to convert a folder of high‑resolution PNG images to new files while preventing out‑of‑memory crashes.
 * 2. When an application must batch‑process PNGs on a server with limited RAM and ensure each image is saved with default PNG options.
 * 3. When a tool has to read large PNG files from an input directory, apply a custom buffer size hint, and write them to an output directory for further processing.
 * 4. When a background job has to safely load and re‑save many PNG assets without loading the entire image into memory at once.
 * 5. When a CI pipeline needs to verify that a set of PNG resources can be copied and saved programmatically without exhausting system memory.
 */
