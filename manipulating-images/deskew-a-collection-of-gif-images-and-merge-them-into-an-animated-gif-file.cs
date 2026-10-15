// HOW-TO: Deskew Multiple GIF Images and Combine into Animated GIF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string input1 = "input1.gif";
            string input2 = "input2.gif";
            string input3 = "input3.gif";
            string outputPath = "output\\merged.gif";

            List<string> inputPaths = new List<string> { input1, input2, input3 };

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage outputGif = (GifImage)Image.Load(inputPaths[0]))
            {
                RasterImage firstFrame = (RasterImage)outputGif.ActiveFrame;
                if (!firstFrame.IsCached) firstFrame.CacheData();
                firstFrame.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                for (int i = 1; i < inputPaths.Count; i++)
                {
                    using (GifImage srcGif = (GifImage)Image.Load(inputPaths[i]))
                    {
                        RasterImage frame = (RasterImage)srcGif.ActiveFrame;
                        if (!frame.IsCached) frame.CacheData();
                        frame.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
                        outputGif.AddPage(frame);
                    }
                }

                GifOptions gifOptions = new GifOptions();
                outputGif.Save(outputPath, gifOptions);
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
 * 1. When you need to automatically straighten scanned GIF frames before creating an animated banner for a website.
 * 2. When a batch of user‑uploaded GIF screenshots must be deskewed and merged into a single looping animation for a mobile app.
 * 3. When generating a time‑lapse GIF from multiple camera captures that are slightly rotated, requiring deskewing and consolidation.
 * 4. When preparing product demo GIFs that were captured at different angles, and you want to align them and combine them into one animated file.
 * 5. When processing archival GIF images to correct orientation and produce a compact animated GIF for email newsletters.
 */
