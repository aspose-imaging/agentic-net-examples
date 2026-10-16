// HOW-TO: Batch Convert PNG Images to SVG Files in C# with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputFolder = "input";
            string outputFolder = "output";

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in pngFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new SvgOptions();
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a collection of PNG icons into scalable SVG graphics for responsive web design.
 * 2. When a build pipeline must generate vector versions of raster assets without changing the original file names.
 * 3. When a desktop application has to export user‑uploaded PNG pictures to SVG format for further editing in vector tools.
 * 4. When a migration script has to move image assets from a legacy PNG folder to a new SVG directory while keeping the folder structure intact.
 * 5. When you want to perform high‑performance batch image conversion in C# using Aspose.Imaging without writing custom parsing code.
 */
