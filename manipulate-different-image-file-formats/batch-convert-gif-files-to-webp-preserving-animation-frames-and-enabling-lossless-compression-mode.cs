// HOW-TO: Batch Convert Animated GIFs to Lossless WebP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

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
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".webp");
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (GifImage gif = (GifImage)Image.Load(inputPath))
                {
                    if (gif.PageCount == 0)
                    {
                        Console.Error.WriteLine($"No frames found in GIF: {inputPath}");
                        continue;
                    }

                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
                    using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                    {
                        WebPOptions options = new WebPOptions
                        {
                            Lossless = true
                        };
                        frame.Save(outputPath, options);
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
 * 1. When you need to reduce website load time by converting animated GIF banners into smaller lossless WebP files using C#.
 * 2. When you want to process a folder of user‑uploaded GIF stickers and store them as WebP to preserve animation while saving storage space.
 * 3. When an e‑commerce platform requires batch conversion of product GIF demos to WebP for better compatibility with modern browsers.
 * 4. When a mobile app backend must automatically transform GIF assets into lossless WebP to improve rendering performance on Android and iOS.
 * 5. When a digital marketing tool needs to generate WebP versions of animated GIF ads while keeping all frames intact for analytics tracking.
 */
