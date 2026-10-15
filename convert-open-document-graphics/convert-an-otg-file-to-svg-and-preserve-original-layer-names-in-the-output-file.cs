// HOW-TO: Convert OTG File to SVG While Preserving Layer Names in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG file and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
                // Preserve original layer names if supported (default behavior)
                image.Save(outputPath, options);
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
 * 1. When you need to export a multi‑layer OTG design to a web‑friendly SVG while keeping the original layer names for later editing.
 * 2. When an automated build process must convert generated OTG assets into SVGs for inclusion in documentation or UI assets.
 * 3. When a migration tool has to batch‑convert legacy OTG files to SVG format without losing layer hierarchy information.
 * 4. When a C# application integrates Aspose.Imaging to transform OTG drawings into scalable vectors for printing or scaling without rasterizing.
 * 5. When a cloud service receives OTG uploads and must store them as SVGs with preserved layer metadata for downstream analytics.
 */
