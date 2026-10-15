// HOW-TO: Apply Gaussian Blur to Each Frame of an Animated GIF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output/output.gif";

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
                    RasterImage frame = (RasterImage)gif.ActiveFrame;
                    frame.Filter(frame.Bounds, new GaussianBlurFilterOptions(5, 1.0));
                }

                GifOptions gifOptions = new GifOptions();
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
 * 1. When you need to soften the motion of an animated GIF by blurring each frame before publishing it on a website.
 * 2. When creating a stylized slideshow where each GIF frame should have a consistent Gaussian blur effect using Aspose.Imaging for .NET.
 * 3. When preprocessing GIF frames to reduce visual noise before applying further image analysis or computer‑vision algorithms in a C# application.
 * 4. When generating a smooth transition effect for a game sprite sheet stored as an animated GIF by applying a 5‑pixel radius blur to every frame.
 * 5. When optimizing user‑generated GIFs for social media by automatically blurring each frame to achieve a more polished, professional look.
 */
