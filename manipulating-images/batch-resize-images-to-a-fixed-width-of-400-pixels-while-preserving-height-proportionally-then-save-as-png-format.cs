// HOW-TO: Batch Resize Images To 400 Pixels Width And Convert To PNG In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input files
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.png" };
            // Hardcoded output directory
            string outputDirectory = "output";

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    int newWidth = 400;
                    int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                    PngOptions pngOptions = new PngOptions();
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
 * 1. When you need to create web‑ready thumbnails from mixed JPEG and PNG files, resizing each to a fixed 400‑pixel width while preserving the height ratio using Aspose.Imaging for .NET.
 * 2. When you must prepare a batch of product photos for an e‑commerce catalog that requires all images to be 400 px wide PNGs, and you want to automate the process in C#.
 * 3. When you are migrating legacy image assets to a content management system and need to standardize size and format (400 px width PNG) across dozens of files programmatically.
 * 4. When you want to reduce the dimensions of large photographs to a uniform width and save them as lossless PNGs for archival or printing workflows using a single C# script.
 * 5. When you need to process multiple images from a source folder, resize them proportionally, and write the resized PNGs to a separate output directory without manual intervention.
 */
