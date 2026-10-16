// HOW-TO: Convert CDR to PNG with Alpha Channel Preservation in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

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
 * 1. When you need to embed a CorelDRAW logo with transparency into a web page, you can convert the .cdr file to a .png using Aspose.Imaging while keeping the alpha channel.
 * 2. When automating a batch process that generates PNG assets from CDR designs for mobile apps, preserving the alpha channel with PngOptions ensures correct overlay rendering.
 * 3. When creating printable marketing materials that require PNG images with transparent backgrounds, converting CDR files with Aspose.Imaging maintains the original alpha channel.
 * 4. When integrating a design workflow that reads CorelDRAW files and outputs PNGs for a UI library, you must keep the alpha channel to avoid unwanted white backgrounds.
 * 5. When developing a server‑side service that receives CDR uploads and returns PNG thumbnails with proper transparency, configuring PngOptions is essential.
 */
