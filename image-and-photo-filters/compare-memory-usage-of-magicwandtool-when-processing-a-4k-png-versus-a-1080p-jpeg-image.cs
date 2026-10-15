// HOW-TO: Measure MagicWandTool Memory Usage for 4K PNG vs 1080p JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pngInputPath = "input4k.png";
            string jpegInputPath = "input1080.jpg";
            string outputDirectory = "Output";
            string pngOutputPath = Path.Combine(outputDirectory, "output4k.png");
            string jpegOutputPath = Path.Combine(outputDirectory, "output1080.jpg");

            if (!File.Exists(pngInputPath))
            {
                Console.Error.WriteLine($"File not found: {pngInputPath}");
                return;
            }

            if (!File.Exists(jpegInputPath))
            {
                Console.Error.WriteLine($"File not found: {jpegInputPath}");
                return;
            }

            // Process PNG
            long memBeforePng = GC.GetTotalMemory(true);
            using (RasterImage pngImage = (RasterImage)Image.Load(pngInputPath))
            {
                MagicWandTool.Select(pngImage, new MagicWandSettings(10, 10))
                    .Apply();

                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(pngOutputPath, false)
                };
                pngImage.Save();
            }
            long memAfterPng = GC.GetTotalMemory(true);
            long pngMemoryIncrease = memAfterPng - memBeforePng;

            // Process JPEG
            long memBeforeJpeg = GC.GetTotalMemory(true);
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegInputPath))
            {
                MagicWandTool.Select(jpegImage, new MagicWandSettings(10, 10))
                    .Apply();

                Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(jpegOutputPath, false)
                };
                jpegImage.Save();
            }
            long memAfterJpeg = GC.GetTotalMemory(true);
            long jpegMemoryIncrease = memAfterJpeg - memBeforeJpeg;

            Console.WriteLine($"PNG processing memory increase: {pngMemoryIncrease} bytes");
            Console.WriteLine($"JPEG processing memory increase: {jpegMemoryIncrease} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure that applying MagicWand selections on high‑resolution PNGs does not exceed your application’s memory budget.
 * 2. When you want to compare the memory impact of MagicWand processing on lossless PNG versus lossy JPEG files of different resolutions.
 * 3. When you are profiling an image‑editing service and must verify that garbage collection frees resources after each MagicWand operation.
 * 4. When you need to decide whether to store processed images as PNG or JPEG based on their runtime memory consumption in a .NET workflow.
 * 5. When you are troubleshooting out‑of‑memory exceptions in a batch job that uses MagicWandTool on mixed‑resolution image sets.
 */
