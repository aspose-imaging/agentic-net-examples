// HOW-TO: Batch Convert Multi‑Page TIFF to WebP Sequentially in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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

            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
                {
                    int frameCount = tiff.Frames.Length;
                    for (int i = 0; i < frameCount; i++)
                    {
                        tiff.ActiveFrame = tiff.Frames[i];
                        string outputPath = Path.Combine(outputDirectory,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{i}.webp");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        tiff.Save(outputPath, new WebPOptions());
                    }
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
 * 1. When you need to shrink a collection of high‑resolution multi‑page TIFF scans into web‑friendly WebP files without exhausting server memory.
 * 2. When a document‑management system must automatically generate preview images for each page of uploaded TIFF documents.
 * 3. When a cloud‑based image pipeline processes thousands of TIFF files and requires low‑footprint conversion to WebP for faster delivery.
 * 4. When a desktop utility has to extract every frame from large medical imaging TIFFs and save them as lossless WebP thumbnails.
 * 5. When an automated archival workflow must convert legacy TIFF archives to modern WebP format while preserving page order.
 */
