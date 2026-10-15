// HOW-TO: Batch Compress GIF Images and Log Original and Compressed Sizes in C# (Aspose.Imaging for .NET)
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

namespace BatchGifCompressor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input_gifs";
                string outputDirectory = "output_gifs";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all GIF files in the input directory
                string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

                foreach (string inputPath in gifFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Record original file size
                    long originalSize = new FileInfo(inputPath).Length;

                    // Load the GIF image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Determine output path
                        string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set GIF save options (default compression)
                        var saveOptions = new GifOptions();

                        // Save the image with the specified options
                        image.Save(outputPath, saveOptions);
                    }

                    // Record compressed file size
                    long compressedSize = new FileInfo(Path.Combine(outputDirectory, Path.GetFileName(inputPath))).Length;

                    // Log the sizes
                    Console.WriteLine($"{inputPath}: {originalSize} bytes -> {compressedSize} bytes");
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
 * 1. When you need to reduce the storage footprint of many GIF animations before uploading them to a web server.
 * 2. When you want to generate a report comparing original and compressed GIF sizes to evaluate compression efficiency.
 * 3. When an automated build pipeline must process all GIF assets in a folder and output optimized versions.
 * 4. When you are creating a desktop tool that optimizes user‑selected GIF files while showing size savings in the UI.
 * 5. When you need to ensure consistent GIF compression settings across a large media library using Aspose.Imaging in C#.
 */
