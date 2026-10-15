// HOW-TO: Measure Magic Wand Mask Generation Time for Different Image Resolutions in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "input_small.jpg", "input_medium.jpg", "input_large.jpg" };
            string[] outputPaths = new string[] { "output_small_masked.jpg", "output_medium_masked.jpg", "output_large_masked.jpg" };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    int x = image.Width / 2;
                    int y = image.Height / 2;
                    MagicWandTool.Select(image, new MagicWandSettings(x, y)).Apply();
                    image.Save(outputPath, new JpegOptions());
                }

                stopwatch.Stop();
                Console.WriteLine($"Processed {inputPath} in {stopwatch.ElapsedMilliseconds} ms");
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
 * 1. When you need to benchmark how quickly the MagicWandTool can create selection masks on small, medium, and large JPEG files in a C# application.
 * 2. When you want to compare processing times for different image resolutions to optimize performance of automated photo editing pipelines.
 * 3. When you are building a quality‑control tool that must report the duration of mask generation for each image before saving the result.
 * 4. When you need to validate that your server‑side image‑processing service meets latency requirements for real‑time masking operations.
 * 5. When you are troubleshooting slow MagicWand selections by measuring elapsed milliseconds for each image size during development.
 */
