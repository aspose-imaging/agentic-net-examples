// HOW-TO: Extract Each Frame From Animated WebP to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputDir = "output_frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (RasterImage raster in webp.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{frameIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    PngOptions options = new PngOptions();
                    raster.Save(outputPath, options);
                    frameIndex++;
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
 * 1. When you need to split an animated WebP into individual PNG images for further editing or analysis without loading the entire animation into memory.
 * 2. When a server‑side C# application must generate thumbnails for each frame of a WebP animation while keeping memory usage low.
 * 3. When converting WebP frames to PNG for compatibility with tools that only support static images, such as legacy reporting systems.
 * 4. When processing large animated WebP files in a batch job and you want to release resources after each frame to avoid out‑of‑memory errors.
 * 5. When building a media pipeline that extracts and stores each WebP frame as a separate PNG file for use in video or slide‑show creation.
 */
