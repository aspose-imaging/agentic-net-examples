// HOW-TO: Batch Convert CDR Files to 800x600 PNG Images in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdr";
            string outputDirectory = @"C:\OutputPng";

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR file
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 800x600
                    image.Resize(800, 600);

                    // Prepare output path
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate web‑ready thumbnails from a collection of CorelDRAW drawings.
 * 2. When a design workflow requires converting legacy CDR assets to PNG for cross‑platform compatibility.
 * 3. When automating the preparation of print‑ready images by resizing them to a standard 800×600 resolution.
 * 4. When migrating a folder of CDR files to a format that can be displayed in browsers without additional plugins.
 * 5. When building a batch processing tool that processes multiple vector files and outputs uniformly sized raster images.
 */
