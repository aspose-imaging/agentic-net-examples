// HOW-TO: Create Animated GIF from DjVu Pages 8 to 10 in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                List<Image> frames = new List<Image>();

                for (int i = 7; i <= 9; i++)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOpts = new PngOptions();
                        djvu.Pages[i].Save(ms, pngOpts);
                        ms.Position = 0;
                        Image frame = Image.Load(ms);
                        frames.Add(frame);
                    }
                }

                using (Image result = Image.Create(frames.ToArray(), true))
                {
                    GifOptions gifOpts = new GifOptions();
                    result.Save(outputPath, gifOpts);
                }

                foreach (var img in frames)
                {
                    img.Dispose();
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
 * 1. When you need to generate a short looping preview of specific pages from a DjVu document for web display.
 * 2. When you want to extract pages 8‑10 of a scanned DjVu book and combine them into an animated GIF for a presentation slide.
 * 3. When an application must convert selected DjVu pages to PNG frames and then bundle them into a single GIF with custom frame timing for email newsletters.
 * 4. When you are building a document viewer that shows a quick animation of highlighted DjVu pages without loading the entire file.
 * 5. When you have to automate the creation of animated GIFs from multi‑page DjVu files for social media sharing or documentation.
 */
