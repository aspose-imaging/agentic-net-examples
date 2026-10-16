// HOW-TO: Export All Frames from Animated WebP to BMP Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (WebPImage webp = new WebPImage(inputPath))
            {
                if (webp.Pages == null || webp.Pages.Length == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                for (int i = 0; i < webp.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage frame = (RasterImage)webp.Pages[i])
                    {
                        frame.Save(outputPath, new BmpOptions());
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
 * 1. When you need to analyze each individual frame of an animated WebP for quality testing, you can extract them to BMP files using C# and Aspose.Imaging.
 * 2. When converting animated WebP assets into a format compatible with legacy Windows applications that only accept BMP, this code automates the frame‑by‑frame conversion.
 * 3. When performing pixel‑level comparison or computer‑vision preprocessing on every frame of a WebP animation, exporting to BMP provides an uncompressed, easy‑to‑read image for each step.
 * 4. When generating a sequence of still images from a WebP animation for use in documentation or slide decks, the script saves each frame as a separate BMP file.
 * 5. When building a batch processing pipeline that extracts frames from multiple WebP animations for archival or further manipulation, this C# routine handles the extraction and BMP saving automatically.
 */
