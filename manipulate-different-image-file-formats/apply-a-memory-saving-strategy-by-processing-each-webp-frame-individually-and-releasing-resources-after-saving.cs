// HOW-TO: Extract and Save Each Frame of an Animated WebP as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputDir = "frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (WebPImage webp = new WebPImage(inputPath))
            {
                int frameCount = webp.Pages.Length;
                for (int i = 0; i < frameCount; i++)
                {
                    using (RasterImage raster = (RasterImage)webp.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        PngOptions options = new PngOptions();
                        raster.Save(outputPath, options);
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
 * 1. When you need to convert an animated WebP advertisement into individual PNG images for use in a web carousel without exhausting memory.
 * 2. When processing large animated WebP files on a server, extracting each frame as a PNG while releasing resources after each save prevents out‑of‑memory errors.
 * 3. When creating thumbnails for each frame of a WebP animation to display in a mobile app, you can generate PNGs on‑the‑fly with Aspose.Imaging.
 * 4. When preparing frame‑by‑frame analysis of motion in a WebP video for computer‑vision preprocessing, saving each rasterized frame as PNG simplifies downstream processing.
 * 5. When integrating WebP support into a .NET image‑processing pipeline that requires PNG output for legacy tools, extracting frames individually ensures compatibility and efficient memory usage.
 */
