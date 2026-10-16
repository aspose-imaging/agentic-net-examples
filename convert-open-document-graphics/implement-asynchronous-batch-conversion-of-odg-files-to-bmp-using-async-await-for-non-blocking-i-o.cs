// HOW-TO: Asynchronously Convert Multiple ODG Files To BMP In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToBmpBatchConverter
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\Images\ODG";
                string outputFolder = @"C:\Images\BMP";

                // Get all ODG files in the input folder
                string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg");

                var conversionTasks = new List<Task>();

                foreach (string inputPath in odgFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Determine output path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Queue asynchronous conversion
                    conversionTasks.Add(ConvertOdgToBmpAsync(inputPath, outputPath));
                }

                // Await all conversions
                await Task.WhenAll(conversionTasks);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task ConvertOdgToBmpAsync(string inputPath, string outputPath)
        {
            await Task.Run(() =>
            {
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new BmpOptions());
                }
            });
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a large collection of ODG graphics to BMP thumbnails without blocking the UI thread.
 * 2. When a web API receives ODG uploads and must generate BMP versions for legacy components while keeping the server responsive.
 * 3. When you automate image conversion in a CI/CD pipeline and want non‑blocking I/O to speed up the build process.
 * 4. When an image‑processing service must handle many ODG files concurrently and store the BMP results in a separate output folder.
 * 5. When building a desktop application that lets users select an ODG folder and instantly creates BMP files without freezing the application.
 */
