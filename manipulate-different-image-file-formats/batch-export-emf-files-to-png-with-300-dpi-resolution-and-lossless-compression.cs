// HOW-TO: Batch Convert EMF Files to High-Resolution PNG with Lossless Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Aspose.Imaging.Image.Load(inputPath) as EmfImage)
                {
                    if (image == null)
                    {
                        Console.Error.WriteLine($"Failed to load EMF image: {inputPath}");
                        continue;
                    }

                    using (var options = new PngOptions())
                    {
                        options.ResolutionSettings = new ResolutionSetting(300, 300);
                        options.PngCompressionLevel = PngCompressionLevel.ZipLevel6;
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
 * 1. When you need to generate print‑ready PNG assets from a collection of vector EMF logos at 300 DPI for high‑quality marketing materials.
 * 2. When an application must automatically convert user‑uploaded EMF diagrams into lossless PNG images for web preview without manual intervention.
 * 3. When a reporting system has to batch‑process thousands of EMF charts into PNG files with consistent resolution for archival storage.
 * 4. When you want to replace legacy EMF icons with PNG equivalents while preserving visual fidelity and keeping file sizes low using ZipLevel6 compression.
 * 5. When a CI/CD pipeline requires converting EMF drawings to PNG at a specific DPI to ensure consistent rendering across different platforms.
 */
