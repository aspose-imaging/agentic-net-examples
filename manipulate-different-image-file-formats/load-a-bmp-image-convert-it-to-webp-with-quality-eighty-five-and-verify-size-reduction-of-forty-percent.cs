// HOW-TO: Convert BMP to WebP with 85 Quality and Verify 40% Size Reduction in C# (Aspose.Imaging for .NET)
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

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = Path.Combine("Input", "sample.bmp");
                string outputPath = Path.Combine("Output", "sample.webp");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        options.Quality = 85;
                        image.Save(outputPath, options);
                    }
                }

                long inputSize = new FileInfo(inputPath).Length;
                long outputSize = new FileInfo(outputPath).Length;

                if (outputSize <= inputSize * 0.6)
                {
                    Console.WriteLine("Size reduction verified.");
                }
                else
                {
                    Console.WriteLine("Size reduction not achieved.");
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
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to WebP with a specific quality setting.
 * 2. When you want to automate batch processing of legacy bitmap images into modern WebP format while ensuring a minimum 40% reduction in file size.
 * 3. When you must compare original and compressed image sizes programmatically to confirm that compression meets storage or bandwidth targets.
 * 4. When you are building a C# service that prepares user‑uploaded BMP files for mobile apps by re‑encoding them to WebP at 85% quality.
 * 5. When you need to generate WebP thumbnails from BMP sources and validate that the thumbnails are significantly smaller than the originals.
 */
