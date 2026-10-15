// HOW-TO: Convert Multiple DjVu Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputDjvu";
            string outputDirectory = @"C:\OutputPng";

            // Get all DjVu files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.djvu", SearchOption.TopDirectoryOnly);

            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image and save as PNG
                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    djvuImage.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑convert a large collection of scanned DjVu documents to PNG images quickly for web preview.
 * 2. When you want to automate the migration of DjVu archives to a more widely supported PNG format using C# and Aspose.Imaging.
 * 3. When you have limited time and want to speed up DjVu‑to‑PNG conversion by processing files concurrently on multi‑core servers.
 * 4. When you must ensure each output PNG is saved to a specific folder structure while handling missing source files gracefully.
 * 5. When you are building a background service that continuously watches a directory and converts incoming DjVu files to PNG without blocking the main thread.
 */
