// HOW-TO: Convert SVG to 8‑Bit Indexed PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.IndexedColor,
                BitDepth = 8
            };

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce the file size of vector graphics for web delivery by converting SVG files to 8‑bit indexed PNGs in a C# application.
 * 2. When you must generate PNG assets with a limited color palette for legacy systems that only support indexed colors using Aspose.Imaging.
 * 3. When you are automating a batch process that transforms design SVGs into PNG thumbnails with a fixed 256‑color palette for mobile apps.
 * 4. When you want to ensure consistent color mapping across multiple SVG icons by saving them as indexed‑color PNGs in .NET.
 * 5. When you are integrating image conversion into a server‑side service that receives SVG uploads and returns optimized 8‑bit PNGs for faster loading.
 */
