// HOW-TO: Convert Animated GIF to WebP with Frame Delays and Loop Count in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.gif";
            string outputPath = "Output/animation.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int width = gif.Width;
                int height = gif.Height;
                int loopCount = gif.LoopsCount;

                WebPOptions createOptions = new WebPOptions();

                using (WebPImage webp = new WebPImage(width, height, createOptions))
                {
                    foreach (var block in gif.Blocks)
                    {
                        if (block is GifFrameBlock gifFrame)
                        {
                            RasterImage raster = (RasterImage)gifFrame;
                            WebPFrameBlock webpFrame = new WebPFrameBlock(raster)
                            {
                                Duration = (short)gifFrame.FrameTime
                            };
                            webp.AddBlock(webpFrame);
                        }
                    }

                    WebPOptions saveOptions = new WebPOptions
                    {
                        AnimLoopCount = (ushort)loopCount,
                        AnimBackgroundColor = (uint)Aspose.Imaging.Color.White.ToArgb()
                    };

                    webp.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of an animated GIF for web delivery while preserving its original timing and looping behavior, you can convert it to an animated WebP using this code.
 * 2. When building a C# application that generates animated stickers for messaging platforms, you may need to transform GIF animations into WebP format to meet platform requirements.
 * 3. When optimizing assets for a mobile app, you might convert multi‑frame GIFs to WebP to benefit from better compression while keeping the animation speed intact.
 * 4. When creating an automated pipeline that processes user‑uploaded GIFs and stores them as WebP for faster loading, this code ensures frame delays and loop count are retained.
 * 5. When migrating legacy content from GIF to modern web formats, developers can use this snippet to batch‑convert animations while maintaining their original playback characteristics.
 */
