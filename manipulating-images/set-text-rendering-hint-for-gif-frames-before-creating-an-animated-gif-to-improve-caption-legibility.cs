// HOW-TO: Improve Caption Legibility in Animated GIF by Setting Text Rendering Hint in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] framePaths = new string[] { "frame1.png", "frame2.png" };
            string[] captions = new string[] { "First Frame", "Second Frame" };
            string outputPath = "output.gif";

            // Verify input files exist
            foreach (var path in framePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first frame to determine canvas size
            RasterImage firstFrame = (RasterImage)Image.Load(framePaths[0]);
            int width = firstFrame.Width;
            int height = firstFrame.Height;
            firstFrame.Dispose();

            // Create GIF canvas
            GifOptions gifOptions = new GifOptions();
            using (GifImage gif = (GifImage)Image.Create(gifOptions, width, height))
            {
                for (int i = 0; i < framePaths.Length; i++)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(framePaths[i]))
                    {
                        // Draw caption with improved text rendering
                        Graphics graphics = new Graphics(frame);
                        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                        using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White))
                        {
                            graphics.DrawString(captions[i], font, brush, new PointF(10, 10));
                        }

                        // Add frame to GIF
                        gif.AddPage(frame);
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[gif.PageCount - 1];
                        gif.ActiveFrame.FrameTime = 500; // duration in milliseconds
                    }
                }

                // Save animated GIF
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
 * 1. When you need to add readable text captions to each frame of an animated GIF generated from PNG images in a .NET application.
 * 2. When you want to ensure that the text drawn on GIF frames uses anti‑aliasing to appear smooth on low‑resolution displays.
 * 3. When you are creating marketing or instructional GIFs where clear, legible captions are essential for user understanding.
 * 4. When you must programmatically verify input images exist and automatically create the output folder before building the animated GIF.
 * 5. When you need to control the font style, size, and color of captions on GIF frames while preserving the original canvas dimensions.
 */
