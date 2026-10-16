// HOW-TO: Create APNG Animation from Multiple PNGs with Loop Count in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "image1.png";
            string inputPath2 = "image2.png";
            string inputPath3 = "image3.png";
            string outputPath = "animation.apng";

            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            int width, height;
            using (RasterImage first = (RasterImage)Image.Load(inputPath1))
            {
                width = first.Width;
                height = first.Height;
            }

            Source source = new FileCreateSource(outputPath, false);
            ApngOptions options = new ApngOptions
            {
                Source = source,
                ColorType = PngColorType.TruecolorWithAlpha,
                NumPlays = 3,
                DefaultFrameTime = 100
            };

            using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
            {
                string[] inputs = new[] { inputPath1, inputPath2, inputPath3 };
                foreach (string path in inputs)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        apng.AddFrame(frame);
                    }
                }
                apng.Save();
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
 * 1. When you need to combine a series of PNG screenshots into a single animated PNG for a product demo that repeats three times.
 * 2. When you want to generate lightweight web‑friendly animations from user‑uploaded PNG assets without using GIF, specifying the number of plays programmatically.
 * 3. When an e‑learning platform requires step‑by‑step visual instructions packaged as an APNG that loops a set number of times for each lesson slide.
 * 4. When a mobile app creates custom stickers by stitching together PNG layers into an animated PNG with a defined frame delay and loop count.
 * 5. When a reporting tool automatically builds animated charts from PNG chart images, saving the result as an APNG file with a controlled number of repetitions.
 */
