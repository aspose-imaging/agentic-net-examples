// HOW-TO: Create APNG with Loop Count 5 and Test Playback Speed in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 5,
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(source);
                    apng.AddFrame(source);
                    apng.Save();
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
 * 1. When you need to generate an animated PNG that repeats exactly five times for use in web banners or UI animations.
 * 2. When you want to ensure the animation’s frame delay (100 ms) plays consistently across different image viewers and browsers.
 * 3. When you are building a C# tool that programmatically creates APNG files from existing PNG assets using Aspose.Imaging.
 * 4. When you need to test how multiple identical frames affect playback speed and loop behavior in a custom image processing pipeline.
 * 5. When you must automate the creation of APNG files with specific loop counts for compliance with a design specification or marketing guideline.
 */
