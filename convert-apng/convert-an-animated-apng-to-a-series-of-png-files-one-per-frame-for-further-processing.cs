// HOW-TO: Extract Frames from Animated APNG to PNG Files in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "animation.apng");
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The input file is not an APNG image.");
                    return;
                }

                int frameCount = apng.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    var frame = (ApngFrame)apng.Pages[i];
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.png");
                    frame.Save(outputPath, new PngOptions());
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
 * 1. When you need to break down an animated APNG into individual PNG frames for further editing or analysis.
 * 2. When you want to generate separate image assets from each frame of a sprite animation to use in a game engine.
 * 3. When you must preprocess each frame of an APNG for computer‑vision algorithms that only accept static PNG images.
 * 4. When you are creating thumbnail sequences or GIF alternatives by extracting PNG frames from an APNG animation.
 * 5. When you need to archive or compare individual frames of an APNG for quality‑control or version‑tracking purposes.
 */
