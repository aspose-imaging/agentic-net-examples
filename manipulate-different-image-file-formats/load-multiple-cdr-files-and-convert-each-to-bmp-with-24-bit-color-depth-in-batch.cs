// HOW-TO: Batch Convert CDR Files To 24‑Bit BMP In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Bmp;

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
                if (!Path.GetExtension(inputPath).Equals(".cdr", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        };
                        cdr.Save(outputPath, bmpOptions);
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
 * 1. When a graphic design workflow needs to export dozens of CorelDRAW (.cdr) illustrations as high‑color BMP images for legacy Windows applications.
 * 2. When an automated build script must generate 24‑bit bitmap previews of CDR assets for documentation or quality‑control pipelines.
 * 3. When a migration project requires converting a folder of CDR logos into BMP format to be compatible with a third‑party printing system that only accepts BMP files.
 * 4. When a desktop application processes user‑uploaded CDR files and needs to save them as BMPs with a white background for further pixel‑based analysis.
 * 5. When a batch processing tool must rasterize multiple vector CDR pages into BMP files while preserving original dimensions and color depth.
 */
