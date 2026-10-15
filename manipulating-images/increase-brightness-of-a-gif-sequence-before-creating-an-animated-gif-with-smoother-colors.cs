// HOW-TO: Increase Brightness of GIF Frames and Create Animated GIF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage sourceGif = (GifImage)Image.Load(inputPath))
            {
                // Process first frame to obtain canvas size
                sourceGif.ActiveFrame = (GifFrameBlock)sourceGif.Pages[0];
                using (RasterImage firstFrame = (RasterImage)sourceGif.ActiveFrame)
                {
                    if (!firstFrame.IsCached) firstFrame.CacheData();
                    firstFrame.AdjustBrightness(30);
                    firstFrame.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    int width = firstFrame.Width;
                    int height = firstFrame.Height;

                    using (GifImage resultGif = (GifImage)Image.Create(new GifOptions(), width, height))
                    {
                        // Add processed first frame
                        resultGif.AddPage(firstFrame);

                        // Process remaining frames
                        for (int i = 1; i < sourceGif.PageCount; i++)
                        {
                            sourceGif.ActiveFrame = (GifFrameBlock)sourceGif.Pages[i];
                            using (RasterImage frame = (RasterImage)sourceGif.ActiveFrame)
                            {
                                if (!frame.IsCached) frame.CacheData();
                                frame.AdjustBrightness(30);
                                frame.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                                resultGif.AddPage(frame);
                            }
                        }

                        GifOptions saveOptions = new GifOptions
                        {
                            LoopsCount = 0 // infinite loop
                        };
                        resultGif.Save(outputPath, saveOptions);
                    }
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
 * 1. When you need to brighten each frame of an existing GIF and output a smoother‑looking animated GIF using Aspose.Imaging in a C# application.
 * 2. When a web service must preprocess user‑uploaded GIFs by increasing brightness and applying Floyd‑Steinberg dithering before storing them as animated GIFs.
 * 3. When a desktop utility has to batch‑process multiple GIF sequences, adjust their luminance, and generate new animated GIFs with consistent canvas dimensions.
 * 4. When an e‑learning platform wants to enhance the visual clarity of instructional GIF animations by programmatically raising brightness and reducing color banding in .NET.
 * 5. When a game developer needs to modify sprite animation GIFs on the fly, applying brightness correction and dithering to match the game’s lighting conditions before rendering them.
 */
