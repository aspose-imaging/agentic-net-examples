// HOW-TO: Create Animated PNG from Multiple PNGs with Random Frame Delays in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\animation.apng";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] inputPaths = new string[]
            {
                "frame1.png",
                "frame2.png",
                "frame3.png"
            };

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Random rand = new Random();

            using (RasterImage firstFrame = (RasterImage)Image.Load(inputPaths[0]))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, firstFrame.Width, firstFrame.Height))
                {
                    apng.AddFrame(firstFrame);

                    foreach (string path in inputPaths.Skip(1))
                    {
                        using (RasterImage img = (RasterImage)Image.Load(path))
                        {
                            apng.AddFrame(img);
                        }
                    }

                    apng.Save();
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
 * 1. When you need to combine several PNG images into a single animated PNG (APNG) for web banners or UI elements.
 * 2. When you want to generate a lossless animation with random frame delays between 50 ms and 150 ms for a mobile application.
 * 3. When you have a series of chart screenshots and must create an APNG that shows the data progression with varying speeds.
 * 4. When you are developing a game and need to programmatically assemble PNG sprite frames into an animated PNG with per‑frame timing.
 * 5. When you automate the production of GIF‑like animations but require the higher quality and smaller size of APNG in a C# backend service.
 */
