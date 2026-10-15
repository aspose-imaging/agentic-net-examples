// HOW-TO: Convert ODG to PNG Concurrently Using Aspose.Imaging and TPL in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputOdg";
                string outputDirectory = @"C:\OutputPng";

                // Get all ODG files in the input directory
                string[] odgFiles = Directory.GetFiles(inputDirectory, "*.odg", SearchOption.TopDirectoryOnly);

                // Process files in parallel
                Parallel.ForEach(odgFiles, odgPath =>
                {
                    // Verify input file exists
                    if (!File.Exists(odgPath))
                    {
                        Console.Error.WriteLine($"File not found: {odgPath}");
                        return;
                    }

                    // Determine output file path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(odgPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load ODG image and save as PNG
                    using (Image image = Image.Load(odgPath))
                    {
                        image.Save(outputPath, new PngOptions());
                    }

                    Console.WriteLine($"Converted: {odgPath} -> {outputPath}");
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
 * 1. When a batch of OpenDocument graphics (ODG) files needs to be exported as PNG thumbnails for a web gallery, this parallel conversion speeds up the process.
 * 2. When an automated build pipeline must generate PNG assets from ODG source files to include in a mobile app, the code can run the conversions concurrently to reduce build time.
 * 3. When a document management system receives many ODG uploads and must store them as PNG previews for quick viewing, this solution processes all files in parallel on the server.
 * 4. When a desktop utility has to convert a large folder of ODG diagrams to PNG for reporting purposes, using the Task Parallel Library minimizes the waiting time for the user.
 * 5. When a cloud function processes incoming ODG files and needs to output PNG images for downstream services, the parallel approach ensures efficient use of compute resources.
 */
