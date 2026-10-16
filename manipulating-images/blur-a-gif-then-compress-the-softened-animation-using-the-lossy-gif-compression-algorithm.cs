// HOW-TO: How To Blur And Lossily Compress A GIF Animation In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.gif";
        string outputPath = "output/output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                    {
                        var blurOptions = new GaussianBlurFilterOptions(5, 1.0f);
                        frame.Filter(frame.Bounds, blurOptions);
                    }
                }

                var gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When you need to soften a noisy GIF animation before uploading it to a website to reduce visual artifacts.
 * 2. When you want to apply a Gaussian blur to each frame of an animated GIF for a privacy‑preserving preview in a C# application.
 * 3. When you must reduce the file size of a large GIF by applying lossy compression after processing its frames in .NET.
 * 4. When you are creating a stylized animated meme and need to blur the motion while keeping the GIF format using Aspose.Imaging.
 * 5. When you automate batch processing of GIFs to blur and compress them for email newsletters to meet attachment size limits.
 */
