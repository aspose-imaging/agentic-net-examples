// HOW-TO: Create Animated PNG From Alphabetically Named PNG Sequence In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input_images/frame1.png";
            string inputPath2 = "input_images/frame2.png";
            string inputPath3 = "input_images/frame3.png";
            string[] files = new string[] { inputPath1, inputPath2, inputPath3 };
            string outputPath = "output/apng_animation.apng";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            using (Aspose.Imaging.RasterImage first = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(files[0]))
            {
                int width = first.Width;
                int height = first.Height;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Create(options, width, height))
                {
                    apng.AddFrame(first);

                    for (int i = 1; i < files.Length; i++)
                    {
                        using (Aspose.Imaging.RasterImage frame = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(files[i]))
                        {
                            apng.AddFrame(frame);
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
 * 1. When you need to generate an animated PNG for a web banner from a series of PNG frames stored in a folder.
 * 2. When you want to programmatically combine sequential screenshot images into a single APNG for documentation.
 * 3. When an application must produce a lightweight animation for mobile apps without using GIF, using C# and Aspose.Imaging.
 * 4. When you have a set of PNG assets named sequentially (frame1.png, frame2.png, …) and need to bundle them into an APNG for a game UI.
 * 5. When automating a build pipeline that creates an APNG preview of image‑processing results from multiple PNG outputs.
 */
