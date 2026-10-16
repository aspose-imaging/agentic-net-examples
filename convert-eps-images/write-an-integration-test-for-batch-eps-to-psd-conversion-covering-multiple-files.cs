// HOW-TO: Batch Convert Multiple EPS Files to PSD Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Test\EpsFiles";
            string outputDirectory = @"C:\Test\PsdOutput";

            // List of EPS file base names (without extension) to process
            string[] fileNames = new string[] { "sample1", "sample2", "sample3" };

            foreach (var name in fileNames)
            {
                string inputPath = Path.Combine(inputDirectory, name + ".eps");
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, name + ".psd");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PsdOptions();
                    image.Save(outputPath, options);
                }

                if (File.Exists(outputPath))
                {
                    Console.WriteLine($"Successfully converted: {inputPath} -> {outputPath}");
                }
                else
                {
                    Console.Error.WriteLine($"Conversion failed for: {inputPath}");
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
 * 1. When a design studio needs to automate converting a set of EPS artwork files into layered PSD files for Photoshop editing.
 * 2. When a build pipeline must verify that EPS assets are correctly transformed into PSD format before publishing to a digital asset management system.
 * 3. When a developer wants to create an integration test that ensures batch EPS‑to‑PSD conversion works for multiple files using Aspose.Imaging.
 * 4. When a content management system imports vector EPS logos and stores them as PSD files for further raster manipulation.
 * 5. When a QA team needs to confirm that missing EPS files are reported and successful conversions generate the expected PSD output files.
 */
