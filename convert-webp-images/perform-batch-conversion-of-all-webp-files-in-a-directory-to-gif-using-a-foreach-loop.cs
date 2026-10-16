// HOW-TO: Batch Convert WebP Images to GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace WebpToGifBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\Images\Input";
                string outputDirectory = @"C:\Images\Output";

                // Get all WebP files in the input directory
                string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in webpFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path with .gif extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load WebP image and save as GIF
                    using (WebPImage webpImage = new WebPImage(inputPath))
                    {
                        GifOptions gifOptions = new GifOptions();
                        webpImage.Save(outputPath, gifOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to process a folder of WebP graphics and generate GIF versions for web animation compatibility.
 * 2. When an automated build script must convert user‑uploaded WebP assets to GIFs before publishing to a legacy CMS.
 * 3. When a desktop utility has to batch convert images from WebP to GIF for email newsletters that only support GIF.
 * 4. When migrating a photo archive from modern WebP format to GIF for use in older Windows applications that cannot read WebP.
 * 5. When creating a server‑side service that scans a directory, converts each WebP file to GIF, and stores the results for downstream processing.
 */
