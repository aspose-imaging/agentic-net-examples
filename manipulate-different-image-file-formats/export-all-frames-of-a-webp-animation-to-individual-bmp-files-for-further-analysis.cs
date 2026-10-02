// HOW-TO: Export All Frames Of A WebP Animation To BMP Files In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "animation.webp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Input is not a WebP animation.");
                    return;
                }

                int frameCount = webp.Pages.Length;
                for (int i = 0; i < frameCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage frame = (RasterImage)webp.Pages[i])
                    {
                        using (BmpOptions bmpOptions = new BmpOptions())
                        {
                            frame.Save(outputPath, bmpOptions);
                        }
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
 * 1. When you need to extract each frame from a WebP animation for pixel‑level analysis or quality testing, this code saves them as BMP images.
 * 2. When a legacy system only accepts BMP files, you can convert animated WebP content into a series of BMP frames for compatibility.
 * 3. When creating a frame‑by‑frame video thumbnail generator, you can use this code to isolate individual WebP frames before resizing them.
 * 4. When performing automated visual regression tests on animated graphics, extracting frames to BMP ensures a lossless comparison baseline.
 * 5. When building a diagnostic tool that inspects animation timing or color palettes, exporting WebP frames to BMP simplifies further processing in .NET.
 */
