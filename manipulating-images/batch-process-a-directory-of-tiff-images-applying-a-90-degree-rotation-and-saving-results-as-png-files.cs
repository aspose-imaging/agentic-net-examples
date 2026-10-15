// HOW-TO: Batch Rotate TIFF Images 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "input";
            string outputDirectory = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, rotate, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    image.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically rotate a collection of scanned TIFF documents 90° and save them as PNG files for web display.
 * 2. When a photo‑processing pipeline must convert legacy TIFF assets to PNG while correcting orientation before uploading to a content management system.
 * 3. When a desktop application has to batch‑process medical imaging TIFF files, rotate them for proper viewing, and store the results in a lossless PNG format.
 * 4. When you want to streamline the preparation of TIFF maps for GIS software by rotating them and exporting to PNG for faster rendering.
 * 5. When an automated build script must ensure all TIFF icons are correctly oriented and converted to PNG for inclusion in a Windows application’s resources.
 */
