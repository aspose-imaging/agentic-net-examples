// HOW-TO: Batch Convert WMF Files to BMP While Keeping Original Size in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputBmp";

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .bmp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF and save as BMP preserving original dimensions
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
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
 * 1. When you need to migrate a legacy collection of vector WMF graphics to raster BMP format for compatibility with older Windows applications.
 * 2. When an automated build process must generate thumbnail previews in BMP from a folder of WMF icons while preserving their original dimensions.
 * 3. When a document conversion service has to batch‑convert user‑uploaded WMF diagrams to BMP for printing pipelines that only accept bitmap images.
 * 4. When a desktop utility must archive WMF artwork as BMP files without scaling, ensuring the saved images match the source size.
 * 5. When a migration script has to process dozens of WMF files in a directory and output BMP copies to a separate folder for downstream image analysis tools.
 */
