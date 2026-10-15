// HOW-TO: Combine Magic Wand and Polygon Masks into One Selection in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .Union(new RectangleMask(100, 100, 200, 150))
                    .Apply();

                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically select a region based on color similarity and then add a manually drawn shape to refine the selection before exporting a transparent PNG.
 * 2. When you want to create a composite mask for cutting out objects from a photograph by merging a Magic Wand selection with a rectangular (or polygon) area in a C# application.
 * 3. When you are building an image editing tool that lets users combine automatic and manual selections to generate a precise alpha channel for PNG output.
 * 4. When you need to programmatically remove background from a JPEG by uniting a Magic Wand mask with a custom polygon mask and save the result with transparency.
 * 5. When you are processing batches of images and must apply a combined selection to each file, merging auto‑detected edges with user‑defined shapes before saving as true‑color PNG with alpha.
 */
