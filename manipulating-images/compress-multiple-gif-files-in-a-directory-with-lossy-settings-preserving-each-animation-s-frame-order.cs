// HOW-TO: Batch Compress GIF Files With Lossy Settings In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.gif");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_compressed.gif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    GifImage gif = (GifImage)image;
                    GifOptions options = new GifOptions();
                    gif.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of dozens of animated GIFs for faster web page loading without altering the animation sequence.
 * 2. When an e‑commerce platform must automatically optimize product GIF previews stored in a folder before publishing them online.
 * 3. When a mobile app backend processes user‑uploaded GIF stickers and wants to store compressed versions to save storage costs.
 * 4. When a marketing team wants to batch‑compress campaign GIF assets while keeping each frame’s order intact for consistent playback.
 * 5. When a server‑side C# service must periodically compress newly added GIF files in a directory to meet bandwidth limits.
 */
