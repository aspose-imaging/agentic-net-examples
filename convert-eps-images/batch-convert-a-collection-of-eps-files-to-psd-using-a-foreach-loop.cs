// HOW-TO: Batch Convert EPS Files to PSD Using C# Foreach Loop (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchEpsToPsd
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "input";
                string outputFolder = "output";

                foreach (string inputPath in Directory.GetFiles(inputFolder, "*.eps"))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        PsdOptions options = new PsdOptions();
                        image.Save(outputPath, options);
                    }
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
 * 1. When a design team needs to migrate a library of vector EPS artwork into Photoshop PSD files for layer‑based editing in an automated C# workflow.
 * 2. When an e‑commerce platform must generate PSD previews from uploaded EPS logos in bulk before publishing product listings.
 * 3. When a print‑shop software needs to convert multiple client‑supplied EPS files to PSD format to apply raster effects programmatically.
 * 4. When a content management system requires nightly batch processing to transform EPS assets stored in a folder into PSD files for downstream Photoshop automation.
 * 5. When a developer wants to create a simple C# utility that reads EPS files from a directory, saves them as PSD with default options, and organizes the output in a separate folder.
 */
