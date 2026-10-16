// HOW-TO: Batch Resize PNG Images to 640x480 and Convert to BMP in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster && !raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    image.Resize(640, 480);
                    BmpOptions options = new BmpOptions();
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
 * 1. When you need to automatically shrink a collection of PNG screenshots to a standard 640x480 resolution and store them as BMP files for legacy Windows applications.
 * 2. When a photo‑processing service must convert user‑uploaded PNG assets into BMP format with uniform dimensions before archiving them.
 * 3. When a game development pipeline requires batch resizing of texture PNGs to 640x480 and saving them as BMPs for compatibility with an older engine.
 * 4. When an automated reporting tool generates charts as PNGs and you must batch convert them to BMPs at a fixed size for inclusion in a PDF that only supports BMP images.
 * 5. When a desktop utility needs to process all PNG files in a folder, resize each to 640x480, and output BMPs for use in a printing system that expects BMP format.
 */
