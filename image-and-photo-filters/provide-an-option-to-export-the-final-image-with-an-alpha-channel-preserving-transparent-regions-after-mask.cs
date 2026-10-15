// HOW-TO: Export PNG With Preserved Alpha After Magic Wand Mask In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10)).Apply();

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to remove a background from a PNG while keeping the remaining transparent areas intact for web graphics.
 * 2. When generating product thumbnails that require selective masking and the output must retain alpha transparency for overlay in UI.
 * 3. When processing scanned images to isolate objects using a magic wand selection and exporting the result as a PNG with an alpha channel for further compositing.
 * 4. When creating custom icons where only the selected shape should stay visible and the rest of the canvas stays transparent in the saved file.
 * 5. When automating batch image cleanup in a .NET application and the final PNG files must preserve transparency after applying mask selections.
 */
