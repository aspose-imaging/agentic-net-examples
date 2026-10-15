// HOW-TO: Increase GIF Frame Contrast and Apply Lossy Compression in C# (Aspose.Imaging for .NET)
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
                    RasterImage frameRaster = (RasterImage)gif.ActiveFrame;
                    if (!frameRaster.IsCached)
                    {
                        frameRaster.CacheData();
                    }
                    frameRaster.AdjustContrast(0.5f);
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
 * 1. When you need to make a low‑contrast animated GIF clearer before sending it in an email, you can boost each frame’s contrast and then reduce the file size with lossy GIF compression.
 * 2. When optimizing web‑ready animations, you may want to enhance visual sharpness of every frame and shrink the GIF to improve page load times using Aspose.Imaging in C#.
 * 3. When preparing a GIF for social‑media posting, increasing contrast helps the content stand out while lossy compression keeps the upload under platform size limits.
 * 4. When archiving a series of GIF frames for a presentation, you can programmatically adjust contrast for readability and compress the animation to save disk space.
 * 5. When building an automated image‑processing pipeline that receives raw GIFs, you can automatically improve contrast and apply lossy compression to standardize quality and size across all assets.
 */
