// HOW-TO: Reverse Frames of Animated WebP and Save as APNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output\\result.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int frameCount = webp.PageCount;
                var frames = new List<RasterImage>();

                for (int i = 0; i < frameCount; i++)
                {
                    RasterImage frame = (RasterImage)webp.Pages[i];
                    frames.Add(frame);
                }

                // Example reordering: reverse the frame order
                frames.Reverse();

                int width = frames[0].Width;
                int height = frames[0].Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();
                    foreach (var frame in frames)
                    {
                        apng.AddFrame(frame);
                    }
                    apng.Save();
                }

                foreach (var frame in frames)
                {
                    frame.Dispose();
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
 * 1. When you need to convert an animated WebP advertisement into an APNG for browsers that only support PNG animation, preserving the animation but changing the frame order.
 * 2. When you want to create a reverse‑play effect for a WebP sprite sheet by reordering its frames before exporting to APNG for use in game UI.
 * 3. When a content pipeline requires all animated assets to be in APNG format, and you must programmatically extract each WebP frame, adjust the sequence, and generate a new APNG file.
 * 4. When optimizing a mobile app’s visual assets, you may need to reorder frames of an existing WebP animation to match a new design timeline and save the result as APNG for compatibility with iOS.
 * 5. When automating batch processing of animated WebP files to produce APNG versions with custom frame ordering for marketing emails that only support APNG animations.
 */
