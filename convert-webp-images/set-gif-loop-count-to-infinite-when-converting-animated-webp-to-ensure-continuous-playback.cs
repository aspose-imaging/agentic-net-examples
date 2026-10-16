// HOW-TO: Convert Animated WebP to Infinite Loop GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animated.webp";
            string outputPath = "Output/animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                gifOptions.LoopsCount = 0;
                image.Save(outputPath, gifOptions);
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
 * 1. When you need to embed an animated WebP advertisement on a website that only supports GIFs and must play continuously without stopping.
 * 2. When creating a slideshow for digital signage where the original animation is in WebP but the player requires a looping GIF for seamless playback.
 * 3. When converting user‑generated animated stickers from WebP to GIF for messaging apps that expect an infinite loop animation.
 * 4. When migrating legacy assets to a new platform that only reads GIF files and you want the animation to repeat forever.
 * 5. When generating animated email content where the source is WebP but the email client only supports GIFs with continuous looping.
 */
