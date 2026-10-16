// HOW-TO: Batch Convert and Rename EMF Files to Sequential PNGs in C# (Aspose.Imaging for .NET)
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

namespace EmfBatchConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDir = @"C:\InputEmf";
                string outputDir = @"C:\OutputPng";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputDir);

                string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");
                int counter = 1;

                foreach (string emfPath in emfFiles)
                {
                    if (!File.Exists(emfPath))
                    {
                        Console.Error.WriteLine($"File not found: {emfPath}");
                        return;
                    }

                    using (Image image = Image.Load(emfPath))
                    {
                        string outputPath = Path.Combine(outputDir, $"{counter:D3}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        image.Save(outputPath, new PngOptions());
                    }

                    counter++;
                }
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
 * 1. When you need to automate the conversion of a large set of Windows Metafile (EMF) diagrams into web‑friendly PNG images with consistent sequential filenames.
 * 2. When a reporting system generates charts as EMF files and you must rename them to a numeric order before publishing them on a website.
 * 3. When migrating legacy design assets stored as EMF into a modern asset pipeline that requires PNG format and predictable naming for batch processing.
 * 4. When creating a build step that transforms EMF icons into PNG sprites and ensures the output files are numbered for easy indexing in a game engine.
 * 5. When a document conversion service must process incoming EMF files, rename them to avoid name collisions, and store them as PNGs for downstream OCR or thumbnail generation.
 */
