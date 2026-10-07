// HOW-TO: Convert TIFF to APNG with Dimension Based Frame Delay in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                using (Image img = Image.Load(file))
                {
                    if (!(img is RasterImage rasterImg))
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {file}");
                        continue;
                    }

                    int width = rasterImg.Width;
                    int height = rasterImg.Height;
                    uint delay = (uint)((width + height) / 10);
                    if (delay == 0) delay = 1;

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".apng");
                    string outDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = delay,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(apngOptions, width, height))
                    {
                        apng.AddFrame(rasterImg);
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
 * 1. When you need to automatically convert a folder of high‑resolution TIFF scans into animated PNGs where each frame’s display time reflects the image size.
 * 2. When a web application must generate lightweight APNG assets from legacy TIFF files and wants the animation speed to adapt to varying dimensions.
 * 3. When a digital publishing workflow requires batch processing of multi‑page TIFF documents into single‑frame APNGs with custom delay values calculated from width and height.
 * 4. When you are building a C# utility that prepares product‑catalog images by turning TIFF pictures into APNGs and ensuring larger images stay on screen longer.
 * 5. When a game‑dev pipeline needs to transform TIFF sprite sheets into APNG animations, using image dimensions to set appropriate frame delays for smoother playback.
 */
