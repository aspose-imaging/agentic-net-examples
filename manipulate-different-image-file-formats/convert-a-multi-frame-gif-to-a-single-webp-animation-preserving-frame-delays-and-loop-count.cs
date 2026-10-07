// HOW-TO: Convert Multi‑Frame GIF to Animated WebP with Loop Count in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "Output\\output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                var webpOptions = new WebPOptions();
                webpOptions.AnimLoopCount = (ushort)gif.LoopsCount;
                gif.Save(outputPath, webpOptions);
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
 * 1. When you need to replace a legacy animated GIF with a smaller WebP animation while keeping the original frame timing and repeat behavior for faster web page loading.
 * 2. When a mobile app must display an animated image and you want to use WebP to reduce bandwidth without losing the GIF’s animation sequence.
 * 3. When an e‑commerce platform wants to generate product showcase animations from user‑uploaded GIFs and store them as WebP to improve SEO and page speed.
 * 4. When a game developer converts sprite sheet animations stored as GIFs into WebP for smoother playback and consistent loop counts across devices.
 * 5. When a content management system automates image processing and needs to preserve GIF loop settings while converting to WebP for modern browsers.
 */
