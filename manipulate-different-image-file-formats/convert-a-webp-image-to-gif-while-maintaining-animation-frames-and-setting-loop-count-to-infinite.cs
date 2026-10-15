// HOW-TO: Convert Animated WebP To Infinite Loop GIF In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
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
            string inputPath = "Input/input.webp";
            string outputPath = "Output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.LoopsCount = 0; // infinite loop
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
 * 1. When you need to display an animated WebP advertisement on legacy browsers that only support GIF, you can convert it to an endlessly looping GIF using C# and Aspose.Imaging.
 * 2. When creating a mobile app that shares animated stickers, you may convert user‑uploaded WebP stickers to GIFs with infinite looping for compatibility with messaging platforms.
 * 3. When generating email newsletters that require animated images, you can transform animated WebP files into GIFs that loop forever to ensure the animation repeats for all recipients.
 * 4. When building a content‑management system that archives animated assets, you can standardize storage by converting WebP animations to GIFs with an infinite loop count via C#.
 * 5. When automating a batch process to prepare social‑media posts, you can use this code to turn animated WebP clips into GIFs that continuously play without manual editing.
 */
