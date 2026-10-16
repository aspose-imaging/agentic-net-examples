// HOW-TO: Batch Convert CDR Files to PSD with Layer Preservation in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".psd");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PsdOptions options = new PsdOptions())
                    {
                        options.VectorizationOptions = new PsdVectorizationOptions
                        {
                            VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                        };
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
 * 1. When a design studio needs to migrate multiple CorelDRAW (.cdr) illustrations into Photoshop (.psd) files while keeping each vector layer separate for further editing.
 * 2. When an automated build pipeline must generate PSD assets from a folder of CDR source files for use in a web‑based graphics editor.
 * 3. When a print‑production workflow requires converting a batch of client‑provided CDR logos into layered PSDs to apply spot‑color separations in Photoshop.
 * 4. When a digital asset management system needs to index vector graphics and store them as PSDs with original layers for easy preview and version control.
 * 5. When a SaaS application offers users the ability to upload CDR files and receive downloadable PSD files that retain the original layer hierarchy for collaborative design work.
 */
