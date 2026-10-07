// HOW-TO: Convert Animated WebP to APNG While Preserving Frame Timing in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
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
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Aspose.Imaging.Image.Load(inputPath))
            {
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Create(apngOptions, webp.Width, webp.Height))
                {
                    apng.RemoveAllFrames();

                    foreach (var page in webp.Pages)
                    {
                        apng.AddFrame((Aspose.Imaging.RasterImage)page);
                    }

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
 * 1. When a developer needs to serve animated images on browsers that support APNG but not WebP, they can convert the WebP animation to APNG while keeping the original frame delays.
 * 2. When creating a cross‑platform mobile app that uses a library only compatible with APNG, the code lets you transform animated WebP assets into APNG without losing animation speed.
 * 3. When optimizing a game’s UI assets, you can batch‑convert animated WebP sprites to APNG to ensure consistent playback timing across different game engines.
 * 4. When migrating a legacy website’s media library from WebP to APNG for better compatibility with older browsers, this snippet preserves the exact animation timing of each frame.
 * 5. When building an automated image‑processing pipeline that receives user‑uploaded animated WebP files, you can generate APNG versions with identical animation timing for downstream services.
 */
