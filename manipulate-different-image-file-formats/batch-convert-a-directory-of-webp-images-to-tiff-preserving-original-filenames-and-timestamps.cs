// HOW-TO: Batch Convert WebP Images to TIFF While Preserving Filenames and Timestamps in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        image.Save(outputPath, options);
                    }
                }

                DateTime creationTime = File.GetCreationTime(inputPath);
                DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
                File.SetCreationTime(outputPath, creationTime);
                File.SetLastWriteTime(outputPath, lastWriteTime);
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
 * 1. When you need to migrate a collection of WebP assets to TIFF for archival or printing while keeping the original file names intact.
 * 2. When an application must process a folder of WebP photos and output TIFF files for compatibility with legacy systems that only read TIFF.
 * 3. When you want to preserve the original creation and modification dates of images after converting them from WebP to TIFF for audit trails.
 * 4. When automating a nightly job that converts newly added WebP screenshots into high‑resolution TIFFs for further analysis.
 * 5. When integrating Aspose.Imaging into a C# service that batch‑converts user‑uploaded WebP images to TIFF without losing metadata.
 */
