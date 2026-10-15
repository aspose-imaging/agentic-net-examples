// HOW-TO: Extract Each Frame from Animated GIF and Save as PNG Files in C# (Aspose.Imaging for .NET)
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

namespace GifFrameExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.gif";
                string outputFolder = "output_frames";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(outputFolder);

                using (Image image = Image.Load(inputPath))
                {
                    if (image is IMultipageImage multipage)
                    {
                        int index = 0;
                        foreach (var page in multipage.Pages)
                        {
                            string outputPath = Path.Combine(outputFolder, $"frame_{index:D4}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            var pngOptions = new PngOptions();
                            page.Save(outputPath, pngOptions);
                            index++;
                        }
                    }
                    else
                    {
                        string outputPath = Path.Combine(outputFolder, "frame_0000.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to break down an animated GIF into individual PNG frames for creating a sprite sheet or video editing.
 * 2. When you want to generate high-quality PNG thumbnails for each animation step to display in a web gallery.
 * 3. When you are preprocessing GIF animations for machine-learning models that require separate image inputs.
 * 4. When you must archive every frame of a GIF as lossless PNG files for compliance or documentation purposes.
 * 5. When you are building a custom slideshow that loads each GIF frame as a separate PNG to apply per-frame effects in a C# application.
 */
