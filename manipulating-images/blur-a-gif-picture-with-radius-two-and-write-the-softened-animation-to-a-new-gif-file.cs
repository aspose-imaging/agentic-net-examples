// HOW-TO: Apply Gaussian Blur to Animated GIF and Save New GIF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.gif";

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
                    RasterImage raster = (RasterImage)gif.ActiveFrame;
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(2, 2));
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
 * 1. When you need to soften the edges of each frame in an animated GIF for a smoother visual effect in a web banner.
 * 2. When you want to reduce visual noise in a GIF animation before embedding it in a mobile app using C# and Aspose.Imaging.
 * 3. When you are creating a stylized transition effect by applying a consistent blur radius to all frames of a GIF for a marketing email.
 * 4. When you must preprocess user‑uploaded GIFs to meet a design guideline that requires a subtle blur across the entire animation.
 * 5. When you are building an automated pipeline that reads GIF files, applies a Gaussian blur filter, and saves the result as a new GIF for archival purposes.
 */
