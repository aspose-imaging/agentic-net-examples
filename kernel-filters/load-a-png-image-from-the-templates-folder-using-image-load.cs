// HOW-TO: Load PNG From Templates Folder And Save With Aspose Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageSignatureExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "templates/input.png";
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = "output/result.png";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Example operation: simply save the loaded image as PNG to the output path
                    var options = new PngOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to read a template PNG, apply processing, and store the result in a specific output directory using Aspose.Imaging in a C# application.
 * 2. When an automated report generator must load a base PNG logo from a shared templates folder and save a copy to a generated reports folder.
 * 3. When a web service processes user‑uploaded images by first loading a predefined PNG watermark from a templates path before further manipulation.
 * 4. When a batch job copies a source PNG to a new location while ensuring the image is correctly parsed and saved with Aspose’s PNG options.
 * 5. When a desktop utility validates the existence of a template image and creates an output folder structure before saving the image for later editing.
 */
