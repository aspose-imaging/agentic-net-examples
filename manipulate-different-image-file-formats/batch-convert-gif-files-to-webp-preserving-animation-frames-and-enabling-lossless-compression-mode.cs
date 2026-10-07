// HOW-TO: Batch Convert Animated GIFs to Lossless WebP in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                if (!inputPath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                    continue;

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image gifImage = Image.Load(inputPath))
                {
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };
                    gifImage.Save(outputPath, options);
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
 * 1. When you need to reduce the size of animated GIF assets for a web app while keeping the animation intact and using lossless WebP compression.
 * 2. When you want to automate the conversion of a folder of GIF stickers into WebP format for faster loading on mobile devices.
 * 3. When you are preparing a batch of product demo animations for an e‑commerce site and require lossless quality to avoid visual artifacts.
 * 4. When you need to integrate GIF‑to‑WebP conversion into a CI/CD pipeline to ensure all uploaded animations meet a standardized format.
 * 5. When you are migrating legacy GIF banners to a modern image format and must preserve each frame’s timing without sacrificing image fidelity.
 */
