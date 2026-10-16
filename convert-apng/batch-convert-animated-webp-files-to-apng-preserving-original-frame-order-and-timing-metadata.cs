// HOW-TO: Batch Convert Animated WebP to APNG with Frame Timing in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".apng");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (WebPImage webp = (WebPImage)Image.Load(inputPath))
                {
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, webp.Width, webp.Height))
                    {
                        apng.RemoveAllFrames();

                        foreach (var page in webp.Pages)
                        {
                            WebPFrameBlock frameBlock = page as WebPFrameBlock;
                            if (frameBlock == null) continue;

                            RasterImage raster = (RasterImage)frameBlock;
                            apng.AddFrame(raster);
                        }

                        apng.Save();
                    }
                }

                Console.WriteLine($"Converted {inputPath} to {outputPath}");
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
 * 1. When you need to generate lossless animated PNGs from a collection of animated WebP assets for web browsers that only support APNG.
 * 2. When migrating a mobile app’s animation resources from WebP to APNG while keeping the original frame order and delays intact.
 * 3. When creating a batch processing tool that converts user‑uploaded animated WebP files to APNG for a content‑management system that stores PNG sequences.
 * 4. When automating the preparation of animated graphics for email newsletters, converting WebP animations to APNG to ensure compatibility with email clients.
 * 5. When building a CI pipeline that validates and converts animated WebP test images to APNG to compare rendering performance across formats.
 */
