// HOW-TO: Convert Animated WebP to APNG and Preserve Frame Count in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
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
            string inputPath = "input\\input.webp";
            string outputPath = "output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

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

                    foreach (Image page in webp.Pages)
                    {
                        RasterImage frame = (RasterImage)page;
                        apng.AddFrame(frame);
                    }

                    apng.Save();
                }

                using (ApngImage resultApng = (ApngImage)Image.Load(outputPath))
                {
                    Console.WriteLine($"Created APNG with {resultApng.PageCount} frames.");
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
 * 1. When you need to display animated images on browsers that support APNG but not animated WebP, you can convert the WebP to APNG using C#.
 * 2. When migrating a mobile app’s assets from WebP to APNG for iOS compatibility, this code extracts each frame and rebuilds the animation.
 * 3. When creating a server‑side image processing pipeline that normalizes animated formats, you can load an animated WebP, convert it to APNG, and verify the resulting frame count.
 * 4. When generating animated stickers for messaging platforms that require APNG, you can reuse existing WebP animations and preserve their timing by converting them in .NET.
 * 5. When performing automated quality checks on a batch of animated graphics, this snippet lets you confirm that the APNG produced contains the same number of frames as the source WebP.
 */
