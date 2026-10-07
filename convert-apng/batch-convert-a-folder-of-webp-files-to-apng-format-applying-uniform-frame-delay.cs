// HOW-TO: Batch Convert WebP Images to APNG with Uniform Frame Delay in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (WebPImage webp = (WebPImage)Image.Load(inputPath))
                {
                    int width = webp.Width;
                    int height = webp.Height;

                    ApngOptions options = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 100u,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(options, width, height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(webp);
                        apng.Save();
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
 * 1. When you need to automatically transform a collection of WebP animation files into APNG format for web deployment while ensuring each frame displays for the same duration, this code provides a ready‑to‑use solution.
 * 2. If your application must generate animated PNGs from user‑uploaded WebP stickers or emojis and you want a consistent frame timing across all output files, the sample shows how to achieve it in bulk.
 * 3. For a CI/CD pipeline that prepares assets for a mobile game, you can use this script to convert dozens of WebP spritesheets into APNGs with a fixed delay, simplifying asset management.
 * 4. When migrating a legacy image library that stores animated WebP files to a format supported by older browsers, the code lets you batch‑process the folder and produce APNGs with a uniform frame rate.
 * 5. If you are building a server‑side service that receives WebP animations and must return APNGs with a standardized playback speed, this example demonstrates the necessary Aspose.Imaging calls in C#.
 */
