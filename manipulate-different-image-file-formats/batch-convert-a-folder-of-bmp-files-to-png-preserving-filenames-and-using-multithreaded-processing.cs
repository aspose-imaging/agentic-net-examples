// HOW-TO: Batch Convert BMP Files to PNG Using Parallel Processing in C# (Aspose.Imaging for .NET)
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

namespace BatchConvert
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\Images\Input";
                string outputFolder = @"C:\Images\Output";

                // Get all BMP files in the input folder
                string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp", SearchOption.TopDirectoryOnly);

                // Process files in parallel
                Parallel.ForEach(bmpFiles, inputPath =>
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path with .png extension
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load BMP and save as PNG
                    using (Image image = Image.Load(inputPath))
                    {
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly convert a large collection of legacy BMP images to PNG for web delivery while preserving original filenames.
 * 2. When an automated build or deployment script must generate PNG assets from BMP sources on a Windows server.
 * 3. When a desktop application processes user‑uploaded BMP screenshots and stores them as compressed PNG files to save disk space.
 * 4. When a batch job runs nightly to migrate image libraries from BMP to PNG format using multithreaded execution for better performance.
 * 5. When you want to integrate Aspose.Imaging into a C# service that transforms legacy bitmap assets into PNG without manual file handling.
 */
