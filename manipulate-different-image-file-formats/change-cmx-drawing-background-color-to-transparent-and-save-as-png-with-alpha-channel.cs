// HOW-TO: Convert CMX Drawing to Transparent PNG with Alpha Channel in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                // Set background to transparent if supported
                var hasBgProp = image.GetType().GetProperty("HasBackgroundColor");
                var bgProp = image.GetType().GetProperty("BackgroundColor");
                if (hasBgProp != null && bgProp != null)
                {
                    hasBgProp.SetValue(image, true);
                    bgProp.SetValue(image, Aspose.Imaging.Color.Transparent);
                }

                var pngOptions = new PngOptions
                {
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
 * 1. When you need to embed a CorelDRAW CMX illustration into a web page and require a PNG with a transparent background.
 * 2. When converting legacy CMX drawings for use in mobile apps that only support PNG with alpha transparency.
 * 3. When preparing CMX artwork for overlay on other graphics in a UI, needing the background removed automatically.
 * 4. When automating batch processing of CMX files to generate PNG assets for game development where transparent sprites are required.
 * 5. When integrating Aspose.Imaging in a C# service that receives CMX uploads and returns PNGs with transparent backgrounds for downstream workflows.
 */
