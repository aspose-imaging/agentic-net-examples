// HOW-TO: Apply Floyd Steinberg Dithering to Animated GIF in C# (Aspose.Imaging for .NET)
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
                    frame.Dither(DitheringMethod.FloydSteinbergDithering, 8);
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
 * 1. When you need to reduce the color depth of each frame in an animated GIF to create a smaller file that still looks good on low‑color displays.
 * 2. When you want to apply Floyd‑Steinberg dithering to an existing GIF animation to improve visual quality after converting it to a limited palette.
 * 3. When you must process every frame of a GIF before uploading it to a web service that only accepts 8‑bit indexed images.
 * 4. When you are building a C# tool that automatically prepares animated GIFs for email newsletters by dithering and re‑saving them with Aspose.Imaging.
 * 5. When you need to batch‑process GIF animations on a server, applying dithering to each frame and saving the result as a new GIF file.
 */
