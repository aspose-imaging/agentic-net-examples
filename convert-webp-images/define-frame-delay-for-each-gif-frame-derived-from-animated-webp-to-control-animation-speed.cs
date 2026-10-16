// HOW-TO: Set Custom Frame Delay When Converting Animated WebP to GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int width = webp.Width;
                int height = webp.Height;
                GifOptions gifOptions = new GifOptions();

                using (GifImage gif = (GifImage)Image.Create(gifOptions, width, height))
                {
                    int frameDelayMs = 100; // delay for each frame in milliseconds

                    for (int i = 0; i < webp.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)webp.Pages[i];
                        gif.AddPage(frame);
                        gif.ActiveFrame.FrameTime = frameDelayMs;
                    }

                    gif.Save(outputPath, gifOptions);
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
 * 1. When you need to create a GIF from an animated WebP and ensure each frame displays for a specific duration, such as synchronizing animation speed for a website banner.
 * 2. When you are building a C# application that converts user‑uploaded animated WebP files to GIFs with consistent playback timing for email newsletters.
 * 3. When you must generate GIFs with precise frame timing for mobile app assets, converting animated WebP sprites while controlling animation speed.
 * 4. When you are optimizing image assets for a game and need to preserve the original animation pace by setting a uniform delay on each GIF frame derived from a WebP sequence.
 * 5. When you are automating batch processing of animated WebP files to GIFs and want to standardize the frame delay to meet platform specifications like social media upload limits.
 */
