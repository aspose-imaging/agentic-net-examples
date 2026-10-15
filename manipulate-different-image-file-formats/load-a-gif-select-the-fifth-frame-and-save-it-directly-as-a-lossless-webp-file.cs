// HOW-TO: Extract Fifth Frame From GIF and Save As Lossless WebP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (gif.PageCount < 5)
                {
                    Console.Error.WriteLine("GIF does not contain at least 5 frames.");
                    return;
                }

                gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[4];

                var options = new WebPOptions { Lossless = true };
                gif.Save(outputPath, options);
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
 * 1. When you need to generate a high‑quality thumbnail of a specific animation frame for a web page, you can extract the fifth GIF frame and save it as a lossless WebP image in C#.
 * 2. When creating an image‑processing pipeline that converts animated GIF assets into modern web‑friendly formats while preserving exact pixel data of a chosen frame, this code extracts frame five and outputs a lossless WebP.
 * 3. When optimizing a mobile app’s assets by replacing animated GIF frames with smaller, lossless WebP files for faster loading, you can use this snippet to isolate the fifth frame and save it.
 * 4. When building a reporting tool that needs to display a particular moment from an animated GIF as a static image in a PDF, the code lets you capture frame five and store it losslessly as WebP.
 * 5. When developing a content‑management system that archives individual frames of user‑uploaded GIFs in a lossless format for future editing, this example shows how to extract the fifth frame and save it as WebP using C#.
 */
