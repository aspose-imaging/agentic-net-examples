// HOW-TO: Batch Convert BMP Files to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = "input";
            string outputFolder = "output";

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string bmpPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Prepare output path with same filename but .png extension
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(bmpPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image and save as PNG
                using (Image image = Image.Load(bmpPath))
                {
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
 * 1. When you need to migrate a legacy collection of BMP assets to PNG for web delivery while keeping the original file names.
 * 2. When an automated build process must generate PNG thumbnails from BMP source images stored in a folder.
 * 3. When a desktop application imports user‑uploaded BMP pictures and saves them as PNG to reduce file size without losing naming consistency.
 * 4. When a server‑side service processes a batch of scanned BMP documents and converts them to lossless PNG for archival storage.
 * 5. When a migration script updates an image repository by converting all BMP files to PNG to ensure compatibility with modern image viewers.
 */
