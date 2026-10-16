// HOW-TO: Combine Multiple Magic Wand Selections with Feathering and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .Union(new MagicWandSettings(150, 150))
                    .Union(new MagicWandSettings(250, 250))
                    .GetFeathered(new FeatheringSettings() { Size = 8 })
                    .Apply();

                PngOptions pngOptions = new PngOptions
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
 * 1. When you need to merge several non‑contiguous regions selected by the Magic Wand tool into a single mask and smooth its edges before exporting the result as a PNG with transparency in a C# application.
 * 2. When creating a composite selection of objects at different coordinates in a photograph, applying an 8‑pixel feather to blend them naturally, and saving the final image for web use.
 * 3. When automating background removal where multiple foreground areas are selected separately, combined, feathered, and then saved as a true‑color PNG with an alpha channel.
 * 4. When processing scanned documents that require selecting multiple text blocks, unifying the selections, applying a soft edge, and outputting a high‑quality PNG for OCR preprocessing.
 * 5. When developing a graphics editor feature that lets users pick several spots with the Magic Wand, join them into one selection, add a gentle feather effect, and store the edited image in PNG format for further composition.
 */
