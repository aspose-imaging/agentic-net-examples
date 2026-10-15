// HOW-TO: Batch Convert WebP Images to TIFF While Preserving Filenames and Timestamps in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

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
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        image.Save(outputPath, tiffOptions);
                    }
                }

                DateTime creationTime = File.GetCreationTimeUtc(inputPath);
                DateTime lastWriteTime = File.GetLastWriteTimeUtc(inputPath);
                File.SetCreationTimeUtc(outputPath, creationTime);
                File.SetLastWriteTimeUtc(outputPath, lastWriteTime);
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
 * 1. When a developer needs to archive a collection of WebP photos as lossless TIFF files for long‑term storage while keeping the original creation and modification dates.
 * 2. When an image‑processing pipeline must convert user‑uploaded WebP assets to TIFF before feeding them into a legacy system that only accepts TIFF format.
 * 3. When a batch script is required to rename and convert WebP screenshots to TIFF for inclusion in a PDF report, ensuring the file timestamps match the source images.
 * 4. When migrating a website’s media library from WebP to TIFF to comply with a regulatory requirement that mandates preserving original file metadata.
 * 5. When automating the preparation of WebP textures for a printing workflow that requires TIFF files with exact original timestamps for version control.
 */
